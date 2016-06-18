using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTree
{
    class Tree
    {
        public string pageTitle_ { get; }
        public string backColor_ { get; }
        public string textColor_ { get; }
        public string author_ { get; }
        private List<string> files_;
        private List<string> filesName_;

        public Tree(string pageTitle, string backColor, string textColor, string author, List<string> files, List<string> filesName)
        {
            pageTitle_ = pageTitle;
            backColor_ = backColor;
            textColor_ = textColor;
            author_ = author;
            files_ = files;
            filesName_ = filesName;
        }

        public void addFile(string path)
        {
            files_.Add(path);
        }

        public List<string> getFiles() { return files_; }
        public List<string> getFilesName() { return filesName_; }
    }

    class HTMLCreator
    {
        private static string createHead(Tree file)
        {
            string head = "<!DOCTYPE html>\n";
            head += "<html>\n";
            head += "<head>\n";
            head += "\t<title>" + file.pageTitle_ + "</title>\n";
            head += "\t<meta charset=\"UTF-8\">\n";
            head += "\t<meta name=\"viewport\" content =\"width=device-width, initial - scale = 1\">\n";
            head += "\t<link rel=\"stylesheet\" type =\"text/css\" href=\"css.css\">\n";
            head += "\t<link href='https://fonts.googleapis.com/css?family=Raleway' rel='stylesheet' type='text/css'>\n";
            head += "<head>\n";
            return head;
        }

        private static string createBody(Tree file)
        {
            string body = "<body>\n";
            body += "\t<header>\n";
            body += "\t\t<div class=\"container\">\n";
            body += "\t\t\t<h1>" + file.pageTitle_ + "</h1>\n";
            body += "\t\t</div>\n";
            body += "\t</header>\n";
            body += "\t<section>\n";
            for (int i = 0; i < file.getFiles().Count; i++)
            {
                body += "\t\t<div class=\"fileItem\">\n";
                body += "\t\t\t<div class=\"container\">\n";
                body += "\t\t\t\t<a href=\"" + file.getFiles()[i] + "\">" + file.getFilesName()[i] + "</a>\n";
                body += "\t\t\t</div>\n";
                body += "\t\t</div>\n";
            }
            body += "\t</section>\n";
            return body;
        }

        private static string createFoot(Tree file)
        {
            string foot = "\t<footer>\n";
            foot += "\t\t<div class=\"container\">\n";
            foot += "\t\t\t<p>Created by " + file.author_ + "</p>\n";
            foot += "\t\t\t<p>Created by <span class=\"color\">Simple HTML Folder Creator</span> developed by <span class=\"color\">Tomáš Kubala</span></p>\n";
            foot += "\t\t</div>\n";
            foot += "\t</footer>\n";
            return foot;
        }

        private static string createCSS(Tree file)
        {
            string css = "body { margin: 0; padding: 0; width: 100%; height: 100%; font-size: 120%; font-family: 'Raleway', sans-serif; }\n";
            css += "header { background-color: " + file.backColor_ + "; display: flex; justify-content: center; align-items: center; color: " + file.textColor_ + "; }\n";
            css += ".container { margin: 0 auto; width: 90%; }";
            css += ".fileItem { display: flex; justify-content: center; align-items: center; padding-top: 20px; padding-bottom: 20px; ";
            css += "transition: background-color 0.3s; color: #525252; }\n";
            css += ".fileItem:hover { background-color: #ececec; }\n";
            css += "footer { text-align: center; color: " + file.backColor_ + "; margin-top: 70px; margin-bottom: 10px; }\n";
            css += "a:link, a:visited, a:active { text-decoration: none; color: inherit; }\n";
            css += "p:last-child { font-size: 13px; color: #525252; }\n";
            css += ".color { color: " + file.backColor_ + "; }\n";
            return css;
        }

        public static void createDocument(Tree file)
        {

            System.IO.StreamWriter index = new System.IO.StreamWriter("Site\\index.html");
            index.Write(createHead(file));
            index.Write(createBody(file));
            index.Write(createFoot(file));
            index.Close();
            System.IO.StreamWriter css = new System.IO.StreamWriter("Site\\css.css");
            css.Write(createCSS(file));
            css.Close();
        }


    }
}
