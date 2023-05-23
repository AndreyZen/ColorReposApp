using ColorSetApp.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorSetApp.Pages
{
    /// <summary>
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage(Receipt receipt)
        {
            InitializeComponent();

            string html = "<html>\r\n\r\n" +
                "<head>\r\n" +
                "<meta http-equiv=Content-Type content=\"text/html; charset=Unicode\">\r\n" +
                "<meta name=Generator content=\"Microsoft Word 15 (filtered)\">\r\n" +
                "<style>\r\n" +
                "<!--\r\n /* Font Definitions */\r\n " +
                "@font-face\r\n\t" +
                "{font-family:Calibri;\r\n\t" +
                "panose-1:2 15 5 2 2 2 4 3 2 4;}\r\n " +
                "/* Style Definitions */\r\n " +
                "p.MsoNormal, li.MsoNormal, div.MsoNormal\r\n\t" +
                "{margin-top:0cm;\r\n\tmargin-right:0cm;\r\n\t" +
                "margin-bottom:8.0pt;\r\n\tmargin-left:0cm;\r\n\t" +
                "line-height:107%;\r\n\tfont-size:11.0pt;\r\n\t" +
                "font-family:\"Calibri\",sans-serif;}\r\n" +
                ".MsoChpDefault\r\n\t" +
                "{font-family:\"Calibri\",sans-serif;}\r\n" +
                ".MsoPapDefault\r\n\t" +
                "{margin-bottom:8.0pt;\r\n\t" +
                "line-height:107%;}\r\n" +
                "@page WordSection1\r\n\t" +
                "{size:595.3pt 841.9pt;\r\n\t" +
                "margin:2.0cm 42.5pt 2.0cm 3.0cm;}\r\n" +
                "div.WordSection1\r\n\t" +
                "{page:WordSection1;}\r\n" +
                "-->\r\n" +
                "</style>\r\n\r\n" +
                "</head>\r\n\r\n" +
                "<body lang=RU>\r\n\r\n" +
                "<div class=WordSection1>\r\n\r\n" +
                "<p class=MsoNormal>&nbsp;</p>\r\n\r\n\r\n\r\n" +
                "<p class=MsoNormal><b><span style='font-size:14.0pt;line-height:107%;\r\n" +
                "font-family:\"Times New Roman\",serif'>Продавец: ОАО «Азбука цвета»</span></b></p>\r\n\r\n" + //ToDo Написать реальную компанию
                "<p class=MsoNormal><b><span style='font-size:14.0pt;line-height:107%;\r\n" +
                "font-family:\"Times New Roman\",serif'>Адрес: Россия, г. Курск, Карла Маркса ул., д. 15 кв.186</span></b></p>\r\n\r\n" + //ToDo Написать реальный адрес
                "<p class=MsoNormal align=center style='text-align:center'><b><span\r\n" +
                $"style='font-size:14.0pt;line-height:107%;font-family:\"Times New Roman\",serif'>Товарный чек №{receipt.Id} от {receipt.Date.ToString("dd MMMM yyyy", CultureInfo.GetCultureInfo("Ru-ru"))} г.</span></b></p>\r\n\r\n" +
                "<p class=MsoNormal><b><span style='font-size:14.0pt;line-height:107%;\r\n" +
                "font-family:\"Times New Roman\",serif'>Покупатель: Частное лицо</span></b></p>\r\n\r\n" +
                "<table class=MsoTableGrid border=1 cellspacing=0 cellpadding=0\r\n " +
                "style='border-collapse:collapse;border:none'>\r\n" +
                "<tr>\r\n  " +
                "<td width=47 valign=top style='width:35.2pt;border:solid windowtext 2.0pt;\r\n" +
                " padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                "  <p class=MsoNormal align=center style='margin-bottom:0cm;margin-bottom:.0001pt;\r\n" +
                "  text-align:center;line-height:normal'><b><span style='font-size:14.0pt;\r\n" +
                "  font-family:\"Times New Roman\",serif'>№</span></b></p>\r\n" +
                "</td>\r\n" +
                "<td width=95 valign=top style='width:70.9pt;border:solid windowtext 2.0pt;\r\n" +
                "  border-left:none;padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                "  <p class=MsoNormal align=center style='margin-bottom:0cm;margin-bottom:.0001pt;\r\n" +
                "  text-align:center;line-height:normal'><b><span style='font-size:14.0pt;\r\n" +
                "  font-family:\"Times New Roman\",serif'>Код</span></b></p>\r\n" +
                "</td>\r\n" +
                "<td width=350 valign=top style='width:262.2pt;border:solid windowtext 2.0pt;\r\n" +
                " border-left:none;padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                " <p class=MsoNormal align=center style='margin-bottom:0cm;margin-bottom:.0001pt;\r\n" +
                " text-align:center;line-height:normal'><b><span style='font-size:14.0pt;\r\n" +
                "  font-family:\"Times New Roman\",serif'>Товар</span></b></p>\r\n" +
                "</td>\r\n" +
                "<td width=76 valign=top style='width:2.0cm;border:solid windowtext 2.0pt;\r\n" +
                "  border-left:none;padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                "  <p class=MsoNormal align=center style='margin-bottom:0cm;margin-bottom:.0001pt;\r\n" +
                "  text-align:center;line-height:normal'><b><span style='font-size:14.0pt;\r\n" +
                "  font-family:\"Times New Roman\",serif'>Кол-во</span></b></p>\r\n" +
                "</td>\r\n" +
                "<td width=56 valign=top style='width:42.25pt;border:solid windowtext 2.0pt;\r\n" +
                "border-left:none;padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                "  <p class=MsoNormal align=center style='margin-bottom:0cm;margin-bottom:.0001pt;\r\n" +
                "  text-align:center;line-height:normal'><b><span style='font-size:14.0pt;\r\n" +
                "  font-family:\"Times New Roman\",serif'>Ед.</span></b></p>\r\n" +
                "</td>\r\n" +
                "<td width=56 valign=top style='width:60pt;border:solid windowtext 2.0pt;\r\n" +
                "  border-left:none;padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                "  <p class=MsoNormal align=center style='margin-bottom:0cm;margin-bottom:.0001pt;\r\n" +
                "  text-align:center;line-height:normal'><b><span style='font-size:14.0pt;\r\n" +
                "  font-family:\"Times New Roman\",serif'>Цена</span></b></p>\r\n" +
                "</td>\r\n" +
                "<td width=56 valign=top style='width:60pt;border:solid windowtext 2.0pt;\r\n" +
                "  border-left:none;padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                "  <p class=MsoNormal align=center style='margin-bottom:0cm;margin-bottom:.0001pt;\r\n" +
                "  text-align:center;line-height:normal'><b><span style='font-size:14.0pt;\r\n" +
                "  font-family:\"Times New Roman\",serif'>Сумма</span></b></p>\r\n" +
                "</td>\r\n";
            //ToDo Перебор

            int i = 1;
            foreach (var item in receipt.ReceiptProduct)
            {
                html += "</tr>\r\n" +
                       "<tr>\r\n" +
                       "<td width=47 valign=top style='width:35.2pt;border:solid windowtext 2.0pt;\r\n" +
                       "  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                       "  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n" +
                      $"  normal'><b><span style='font-size:14.0pt;font-family:\"Times New Roman\",serif'>{i}</span></b></p>\r\n" +
                       "</td>\r\n" +
                       "<td width=95 valign=top style='width:70.9pt;border-top:none;border-left:none;\r\n" +
                       "  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 2.0pt;\r\n" +
                       "  padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                       "  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n" +
                      $"  normal'><b><span style='font-size:14.0pt;font-family:\"Times New Roman\",serif'>{item.Product.Id}</span></b></p>\r\n" +
                       "</td>\r\n" +
                       "<td width=350 valign=top style='width:262.2pt;border-top:none;border-left:\r\n" +
                       "  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 2.0pt;\r\n" +
                       "  padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                       "  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n" +
                      $"  normal'><b><span style='font-size:14.0pt;font-family:\"Times New Roman\",serif'>{item.Product.Name}\n{item.Product.Description}</span></b></p>\r\n" +
                       "</td>\r\n" +
                       "<td width=76 valign=top style='width:2.0cm;border-top:none;border-left:none;\r\n" +
                       "  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 2.0pt;\r\n" +
                       "  padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                       "  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n" +
                      $"  normal'><b><span style='font-size:14.0pt;font-family:\"Times New Roman\",serif'>{item.Count}</span></b></p>\r\n" +
                       "</td>\r\n" +
                       "<td width=56 valign=top style='width:42.25pt;border-top:none;border-left:\r\n" +
                       "  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 2.0pt;\r\n" +
                       "  padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                       "  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n" +
                      $"  normal'><b><span style='font-size:14.0pt;font-family:\"Times New Roman\",serif'>шт.</span></b></p>\r\n" +
                       "</td>\r\n" +
                       "<td width=56 valign=top style='width:42.25pt;border-top:none;border-left:\r\n" +
                       "  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 2.0pt;\r\n" +
                       "  padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                       "  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n" +
                      $"  normal'><b><span style='font-size:14.0pt;font-family:\"Times New Roman\",serif'>{item.Product.Price}</span></b></p>\r\n" +
                       "</td>\r\n" +
                       "<td width=56 valign=top style='width:42.25pt;border-top:none;border-left:\r\n" +
                       "  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n" +
                       "  padding:0cm 5.4pt 0cm 5.4pt'>\r\n" +
                       "  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n" +
                      $"  normal'><b><span style='font-size:14.0pt;font-family:\"Times New Roman\",serif'>{item.Count * item.Product.Price}</span></b></p>\r\n" +
                       "</td>\r\n";
                i++;
            }



                html += "</tr>\r\n" +
                "</table>\r\n\r\n" +
                "<p class=MsoNormal><b><span style='font-size:14.0pt;line-height:107%;\r\n" +
                "font-family:\"Times New Roman\",serif'>&nbsp;</span></b></p>\r\n\r\n" +
                "<p class=MsoNormal><b><span style='font-size:14.0pt;line-height:107%;\r\n" +
               $"font-family:\"Times New Roman\",serif'>Получено: {receipt.Sum} руб.</span></b></p>\r\n\r\n" +
                "<p class=MsoNormal><b><span style='font-size:14.0pt;line-height:107%;\r\n" +
                "font-family:\"Times New Roman\",serif'>С учетом НДС 20%</span></b></p>\r\n\r\n" +
                "<p class=MsoNormal><span style='font-size:12.0pt;line-height:107%;font-family:\r\n" +
               $"\"Times New Roman\",serif'>Продавец ____________ {App.CurrentUser.Abbreviature}</span></p>\r\n\r\n" +
                "<p class=MsoNormal><span style='font-size:12.0pt;padding: 0px 100px;line-height:150%;font-family:\r\n" +
                "\"Times New Roman\",serif'>М.П.</span></p>\r\n\r\n" +
                "<p class=MsoNormal><span style='font-size:12.0pt;line-height:107%;font-family:\r\n" +
                "\"Times New Roman\",serif'>Товар получил(ла) полностью. Претензий по комплектности, внешнему виду и упаковке, не имею. С правилами гарантийного обслуживания ознакомлен(на).</span></p>\r\n\r\n" +
                "<p class=MsoNormal><span style='font-size:12.0pt;line-height:107%;font-family:\r\n" +
                "\"Times New Roman\",serif'>22 Мая 2023</span></p>\r\n\r\n" +
                "<p class=MsoNormal><span style='font-size:12.0pt;line-height:107%;font-family:\r\n" +
                "\"Times New Roman\",serif'>Покупатель __________________________________</span></p>\r\n\r\n" +
                "</div>\r\n\r\n" +
                "</body>\r\n\r\n" +
                "</html>\r\n";

            WBrowserReport.Navigate(html);
        }
    }
}
