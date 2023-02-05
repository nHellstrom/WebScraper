using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using WebScraper.Models;

HtmlWeb web = new();
HtmlDocument doc = web.Load("https://www.svt.se/");

var HeaderNames = doc.DocumentNode.SelectNodes("//span[@class='nyh_teaser__heading-title']");

var titles = new List<Row>();
foreach (var item in HeaderNames)
{
    titles.Add(new Row { Title = item.InnerText} );
}
string path = Directory.GetCurrentDirectory();
using (var writer = new StreamWriter($"{path}\\svtnyheter.csv"))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.WriteRecords(titles);
}