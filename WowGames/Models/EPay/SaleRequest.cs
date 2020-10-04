using System;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace WowGames.Models.EPay
{

    [XmlRoot(ElementName = "RECEIPT")]
    public class Receipt
    {
        public Receipt()
        {
            CharsPerLine = ConfigurationManager.AppSettings["EPayReceiptCharsPerLine"];
            Language = "POR";
        }

        [XmlElement(ElementName = "CHARSPERLINE")]
        public string CharsPerLine { get; set; }
        [XmlElement(ElementName = "LANGUAGE")]
        public string Language { get; set; }
    }
    [XmlRoot(ElementName = "TERMINALID")]
    public class TerminalId
    {
        public TerminalId()
        {
            RetailerAccount = ConfigurationManager.AppSettings["EPayRetailerAcc"];
            StoreId = ConfigurationManager.AppSettings["EPayStore"];
            Country = "BR";
            Text = ConfigurationManager.AppSettings["EPayTerminal"];
        }
        [XmlAttribute(AttributeName = "RETAILERACC")]
        public string RetailerAccount { get; set; }
        [XmlAttribute(AttributeName = "STOREID")]
        public string StoreId { get; set; }
        [XmlAttribute(AttributeName = "COUNTRY")]
        public string Country { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "REQUEST")]
    public class SaleRequest
    {
        public SaleRequest()
        {
            Username = ConfigurationManager.AppSettings["EPayUser"];
            Password = ConfigurationManager.AppSettings["EPayPassword"];
            LocalDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            TXID = Guid.NewGuid().ToString();
            Currency = 986;
            Type = "SALE";
            TerminalId = new TerminalId();
            Card = new Card();
            Receipt = new Receipt();
        }
        [XmlElement(ElementName = "USERNAME")]
        public string Username { get; set; }

        [XmlElement(ElementName = "PASSWORD")]
        public string Password { get; set; }

        [XmlElement(ElementName = "TERMINALID")]
        public TerminalId TerminalId { get; set; }

        [XmlElement(ElementName = "LOCALDATETIME")]
        public string LocalDateTime { get; set; }

        [XmlElement(ElementName = "TXID")]
        public string TXID { get; set; }

        [XmlElement(ElementName = "CARD")]
        public Card Card { get; set; }
        [XmlElement(ElementName = "AMOUNT")]
        public int Amount { get; set; }
        [XmlElement(ElementName = "RECEIPT")]
        public Receipt Receipt { get; set; }
        [XmlElement(ElementName = "CURRENCY")]
        public int Currency { get; set; }
        [XmlAttribute(AttributeName = "TYPE")]
        public string Type { get; set; }
        public override string ToString()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, this);
                return textWriter.ToString();
            }
        }

    }
}
