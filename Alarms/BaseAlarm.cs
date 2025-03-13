using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OPC_ua_modules
{
    class BaseAlarm
    {
        public string? EventId { get; set; }//������������� �������
        public NodeId? EventType { get; set; }//��� ��䳿 (���������, �� ���������)
        public NodeId? SourceNode { get; set; }//�����, �� �������� �������
        public string? SourceName { get; set; }//�������� ��'� ������� ��䳿
        public LocalizedText? Message { get; set; }//�������� ����������� �������
        public ushort Severity { get; set; }//����� ���������� �������
        public int OnDelay { get; set; }//������������ ���� ��� ������� �������, �� �� ���������� ������� 
        public int OffDelay { get; set; } //������������ ���� ��� ����� �������, �� �� ���������� �������
    }
}