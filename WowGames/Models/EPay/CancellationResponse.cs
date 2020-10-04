using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WowGames.Models.EPay
{

	[XmlRoot(ElementName = "RESPONSE")]
	public class CancellationResponse
	{
		[XmlElement(ElementName = "RESULT")]
		public string Result { get; set; }
		[XmlElement(ElementName = "RESULTTEXT")]
		public string ResultText { get; set; }
		[XmlElement(ElementName = "TERMINALID")]
		public string TerminalId { get; set; }
		[XmlElement(ElementName = "LOCALDATETIME")]
		public string LocalDateATime { get; set; }
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
		[XmlAttribute(AttributeName = "TYPE")]
		public string Type { get; set; }
		public static CancellationResponse LoadFromXML(string xml)
		{
			var xmlSerializer = new XmlSerializer(typeof(CancellationResponse));
			using (TextReader reader = new StringReader(xml))
			{
				return xmlSerializer.Deserialize(reader) as CancellationResponse;
			}
		}
	}
}
