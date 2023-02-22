using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace DotNetMonitor
{
    public class Utility
    {
        public static string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;

                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;

                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }

        public static PEFileKinds GetFileType(string inFilename)
        {
            using (var fs = new FileStream(inFilename, FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[4];
                fs.Seek(0x3C, SeekOrigin.Begin);
                fs.Read(buffer, 0, 4);
                var peoffset = BitConverter.ToUInt32(buffer, 0);
                fs.Seek(peoffset + 0x5C, SeekOrigin.Begin);
                fs.Read(buffer, 0, 1);
                if (buffer[0] == 3)
                {
                    return PEFileKinds.ConsoleApplication;
                }
                else if (buffer[0] == 2)
                {
                    return PEFileKinds.WindowApplication;
                }
                else
                {
                    return PEFileKinds.Dll;
                }
            }
        }
    }
}
