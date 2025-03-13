#!/bin/bash

# Встановлюємо змінні для імен файлів
CA_KEY="ca.key"
CA_CERT="ca.crt"
SERVER_KEY="server.key"
SERVER_CSR="server.csr"
SERVER_CERT="server.crt"
CONFIG_FILE="openssl.cnf"

# Створюємо кореневий (CA) ключ і сертифікат
openssl genpkey -algorithm RSA -out $CA_KEY -aes256 -pass pass:password
openssl req -x509 -new -nodes -key $CA_KEY -sha256 -days 3650 -out $CA_CERT -passin pass:password \
    -subj "/C=UA/ST=Kyiv/L=Kyiv/O=MyCompany/OU=IT/CN=MyOPCServerCA"

# Генеруємо приватний ключ для сервера
openssl genpkey -algorithm RSA -out $SERVER_KEY

# Створюємо запит на підписування сертифіката (CSR) для сервера
openssl req -new -key $SERVER_KEY -out $SERVER_CSR \
    -subj "/C=UA/ST=Kyiv/L=Kyiv/O=MyCompany/OU=IT/CN=opc.myserver.com"

# Створюємо файл конфігурації OpenSSL для розширень сертифіката сервера
cat > $CONFIG_FILE <<EOL
[req]
distinguished_name=req_distinguished_name
x509_extensions=v3_req
prompt=no
[req_distinguished_name]
C=UA
ST=Kyiv
L=Kyiv
O=MyCompany
OU=IT
CN=opc.myserver.com
[v3_req]
keyUsage=critical,digitalSignature,keyEncipherment
extendedKeyUsage=serverAuth
subjectAltName=@alt_names
[alt_names]
DNS.1=opc.myserver.com
DNS.2=localhost
EOL

# Підписуємо сертифікат сервера кореневим сертифікатом (CA)
openssl x509 -req -in $SERVER_CSR -CA $CA_CERT -CAkey $CA_KEY -CAcreateserial \
    -out $SERVER_CERT -days 3650 -sha256 -extfile $CONFIG_FILE -extensions v3_req -passin pass:password

# Видаляємо файл конфігурації (необов'язково)
rm -f $CONFIG_FILE

# Виводимо повідомлення про завершення
echo "Генерація SSL сертифікатів завершена. Файли:"
echo "Кореневий сертифікат: $CA_CERT"
echo "Кореневий ключ: $CA_KEY (з паролем)"
echo "Сертифікат сервера: $SERVER_CERT"
echo "Приватний ключ сервера: $SERVER_KEY"
