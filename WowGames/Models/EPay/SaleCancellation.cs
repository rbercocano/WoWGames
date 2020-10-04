using System;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace WowGames.Models.EPay
{
    [XmlRoot(ElementName = "CARD")]
    public class Card
    {
        [XmlElement(ElementName = "EAN")]
        public string EAN { get; set; }
    }

    [XmlRoot(ElementName = "REQUEST")]
    public class SaleCancellation
    {

        public SaleCancellation()
        {
            Username = ConfigurationManager.AppSettings["EPayUser"];
            Password = ConfigurationManager.AppSettings["EPayPassword"];
            LocalDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            TXID = Guid.NewGuid().ToString();
            Type = "CANCEL";
            Mode = "AUTOMATIC";
            Currency = 986;
            TerminalId = new TerminalId();
            Card = new Card();
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
        [XmlAttribute(AttributeName = "TYPE")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "MODE")]
        public string Mode { get; set; }

        [XmlElement(ElementName = "TXREF")]
        public string TXREF { get; set; }
        [XmlElement(ElementName = "AMOUNT")]
        public int Amount { get; set; }
        [XmlElement(ElementName = "CURRENCY")]
        public int Currency { get; set; }
        [XmlElement(ElementName = "CARD")]
        public Card Card { get; set; }
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
