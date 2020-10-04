using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WowGames.Models.EPay
{
    [XmlRoot(ElementName = "RECEIPT")]
    public class ReceiptInfo
    {
        [XmlElement(ElementName = "LINES")]
        public int NumberOfLines { get; set; }
        [XmlElement(ElementName = "LINE")]
        public List<string> Lines { get; set; }
        public override string ToString()
        {
            var lines = (Lines ?? new List<string>());
            return string.Join(Environment.NewLine, lines);
        }
    }

    [XmlRoot(ElementName = "PINCREDENTIALS")]
    public class PINCREDENTIALS
    {
        [XmlElement(ElementName = "PIN")]
        public string PIN { get; set; }
        [XmlElement(ElementName = "SERIAL")]
        public string Serial { get; set; }
        [XmlElement(ElementName = "VALIDTO")]
        public string ValidTO { get; set; }
    }

    [XmlRoot(ElementName = "RESPONSE")]
    public class SaleResponse
    {
        [XmlElement(ElementName = "RESULT")]
        public string Result { get; set; }
        [XmlElement(ElementName = "RESULTTEXT")]
        public string ResultText { get; set; }
        [XmlElement(ElementName = "TERMINALID")]
        public string TerminalId { get; set; }
        [XmlElement(ElementName = "LOCALDATETIME")]
        public string LocalDateTime { get; set; }
        [XmlElement(ElementName = "SERVERDATETIME")]
        public string ServerDateTime { get; set; }
        [XmlElement(ElementName = "TXID")]
        public string TXID { get; set; }
        [XmlElement(ElementName = "HOSTTXID")]
        public string HostTXID { get; set; }
        [XmlElement(ElementName = "AMOUNT")]
        public int Amount { get; set; }
        [XmlElement(ElementName = "CURRENCY")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "LIMIT")]
        public string Limit { get; set; }
        [XmlElement(ElementName = "RECEIPT")]
        public ReceiptInfo Receipt { get; set; }
        [XmlElement(ElementName = "PINCREDENTIALS")]
        public PINCREDENTIALS PINCredentials { get; set; }
        [XmlAttribute(AttributeName = "TYPE")]
        public string Type { get; set; }

        public static SaleResponse LoadFromXML(string xml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SaleResponse));
            using (TextReader reader = new StringReader(xml))
            {
                return xmlSerializer.Deserialize(reader) as SaleResponse;
            }
        }
    }
}
