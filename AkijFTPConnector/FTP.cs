using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Collections;

/*************************************************************************************
 * This class used for connecting and executing command to the remote server from client
 * in short By using the Class One can easily develop a FTP Client Program
 * 
 * Devleopd By : Himadri Das
 * Date        : 07/12/2009 Monday
 * Modified    : 20/12/2009
 * Modified    : 20/01/2010 Wednesday
 * Rights      : Akij Group
 *************************************************************************************/


namespace AkijFTPConnector
{
    public class FTP
    {

        private string ftpHost;
        private string userName;
        private string password;
        private string port;
        private string currentDirectory;
        private bool ysnChangeDirectorySuccessful;
        private FtpDirectoryInfo[] directories;
        private FtpFileInfo[] fileName;


        //test

        private Socket clientSocket;
        private int serverResponseCode;
        private string serverResponseString;
        private string serverMessage;
        private bool ysnLogin;
        private int bytes;
        private string[] sep = new string[] { " ", "  ", "   ", "    ", "     ", "      " };

        private static int size = 512;
        private Byte[] buffer = new Byte[size];

        #region Properties

        public string FtpHost
        {
            get
            {
                return ftpHost;
            }
            set
            {
                ftpHost = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }

        public string CurrentDirectory
        {
            get
            {
                return currentDirectory;
            }
        }

        public string ServerMessage
        {
            get
            {
                return serverMessage;
            }
        }

        public bool ysnLogInSuccessed
        {
            get
            {
                return ysnLogin;
            }
        }

        public FtpDirectoryInfo[] Directoreies
        {
            get
            {
                return directories;
            }
        }

        public FtpFileInfo[] FileName
        {
            get
            {
                return fileName;
            }
        }

        public bool YsnChangeDirectorySuccessful
        {
            get
            {
                return ysnChangeDirectorySuccessful;
            }
        }

        #endregion

        public void ContentOfCurrentDirectory(string dirName)
        {
            Socket dataSocket = CreateDataSocket();
            ExecuteCommand("LIST " + dirName);
            
            string completeString = "";
            while ((bytes = dataSocket.Receive(buffer, buffer.Length, 0)) > 0)
            {
                completeString += Encoding.ASCII.GetString(buffer, 0, bytes);
            }

            string[] seperator = new string[] { "\r\n" };
            string[] list = completeString.Split(seperator,StringSplitOptions.None);
            SeperateTheDirectoriesAndFiles(list);
            

           
        }

        // Method For User Login
        public void Login()
        {
            // create a new Socket
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //set the ip end point
            IPEndPoint ip = new IPEndPoint(Dns.Resolve(ftpHost).AddressList[0], int.Parse(port));

            // connect to server
            clientSocket.Connect(ip);

            // get the reply
            ServerResponse();
            // if connects properly then server response must be 220
            if (serverResponseCode != 220)
            {
                Close();
                throw new Exception("Cannot Find The Server!!");
            }

            //send the user name to the Server
            ExecuteCommand("USER " + userName);

            //if user name Ok then server response must be 331
            if (serverResponseCode != 331)
            {
                Close();
                throw new Exception("User name Is Incorrect");
            }

            //send password for the User
            ExecuteCommand("PASS " + password);

            //if user password Ok then server response must be 230

            if (serverResponseCode != 230)
            {
                CleanUP();
                throw new Exception("User Password is Wrong");
            }

            ysnLogin = true;

            // set the current Deirectory
            SetCurrentDirectorty();


        }

        // Method for Make new directory at the current Working Directory
        public void MakeDirectory(string dirName)
        {
            ExecuteCommand("MKD " + dirName);
            if (serverResponseCode != 257)
            {
               // throw new Exception("Cannot Create Directory");
                throw new Exception(serverResponseString);
            }
            
        }

        // Method for Changing Directory at remote server
        public bool ChangeDirectory(string dirName)
        {
            bool flag;
            ExecuteCommand("CWD " + dirName);
            if (serverResponseCode != 250)
            {
                //throw new Exception("Change directory is not Successfull");
                ysnChangeDirectorySuccessful = false;
                flag = false;
            }
            else
            {
                ysnChangeDirectorySuccessful = true;
                flag = true;
            }
            SetCurrentDirectorty();
            return flag;

        }

        //Method for Renaming a directory at remote server
        public void ReNameDirectory(string oldDirName, string newDirName)
        {
            ReNameing(oldDirName, newDirName);
            
        }

        //Method For Deleting a directory from remote Server
        public void DeleteDirectory(string directoryName)
        {
            ExecuteCommand("RMD " + directoryName);
            if (serverResponseCode != 250)
            {
                throw new Exception(serverResponseString);
            }
        }

        // Method For reName a file
        public void ReNameFile(string oldFileName, string newFileName)
        {
            ReNameing(oldFileName, newFileName);
        }

        //Method For deleting a file
        public void DeleteFile(string fileName)
        {
            ExecuteCommand("DELE " + fileName);
            if (serverResponseCode != 250)
            {
                throw new Exception(serverResponseString);
            }

        }

        
        //Method for Uploading a file at the current Directory
        public void UploadFileToServer(string fileName)
        {
            // create and entering to the passive mode
            Socket dataSocket = CreateDataSocket();

            // prepares the Sever to upload the 
            ExecuteCommand("STOR " + Path.GetFileName(fileName));
            if (!(serverResponseCode == 125 || serverResponseCode == 150))
            {
                throw new Exception(serverResponseString);
            }

            Progress progressShow = new Progress();
            
            //Now send the file to the stream
            FileStream inputFile = new FileStream(fileName, FileMode.Open);
            FileInfo fiInfo = new FileInfo(fileName);
            progressShow.Init(fiInfo.Length.ToString(), "Sending........");
            progressShow.Show();
            int tBytes = 0;
            while ((bytes=inputFile.Read(buffer,0,buffer.Length)) > 0)
            {
                dataSocket.Send(buffer, bytes, 0);
                tBytes += bytes;
                progressShow.MoveProgress(tBytes, "send "+tBytes+" bytes from "+fiInfo.Length.ToString()+" bytes");
            }
            progressShow.Close();
            inputFile.Close();

            if (dataSocket.Connected)
            {
                dataSocket.Close();
            }

            ServerResponse();
            if (!(serverResponseCode == 226 || serverResponseCode == 250))
            {
                throw new IOException(serverResponseString);
            }

        }


        public void UploadFileToServerForWeb(Stream inputFile,string fileName)
        {
            // create and entering to the passive mode
            Socket dataSocket = CreateDataSocket();

            // prepares the Sever to upload the 
            ExecuteCommand("STOR " + Path.GetFileName(fileName));
            if (!(serverResponseCode == 125 || serverResponseCode == 150))
            {
                throw new Exception(serverResponseString);
            }

            Progress progressShow = new Progress();

            //Now send the file to the stream
           // FileStream inputFile = new FileStream(fileName, FileMode.Open);
            //FileInfo fiInfo = new FileInfo(fileName);
           // progressShow.Init(fiInfo.Length.ToString(), "Sending........");
           // progressShow.Show();
            int tBytes = 0;
            while ((bytes = inputFile.Read(buffer, 0, buffer.Length)) > 0)
            {
                dataSocket.Send(buffer, bytes, 0);
                tBytes += bytes;
               // progressShow.MoveProgress(tBytes, "send " + tBytes + " bytes from " + fiInfo.Length.ToString() + " bytes");
            }
           // progressShow.Close();
            inputFile.Close();

            if (dataSocket.Connected)
            {
                dataSocket.Close();
            }

            ServerResponse();
            if (!(serverResponseCode == 226 || serverResponseCode == 250))
            {
                throw new IOException(serverResponseString);
            }

        }


        //Method for Downloading a file form the current directory of remote Server
        public void DownloadFileFromServer(string serverFileName, string localFileName)
        {
            //open a file Stream 
            FileStream localFile = new FileStream(localFileName, FileMode.Create);

            // create Data Socket
            Socket dataSocket = CreateDataSocket();

            ExecuteCommand("SIZE " + serverFileName);

          
            string size = serverResponseString.Substring(0, serverResponseString.IndexOf("\r"));

            //send command for Downloading
            ExecuteCommand("RETR " + serverFileName);
            if (!(serverResponseCode == 150 || serverResponseCode == 125))
            {
                throw new Exception(serverResponseString);
            }

            int tempBytes = 0;
            Progress downloadProgress = new Progress();
            downloadProgress.Init(size, "Downloading....");
            downloadProgress.Show();
            // get the sended data form the Socket
            while ((bytes = dataSocket.Receive(buffer, buffer.Length, 0)) > 0)
            {
                localFile.Write(buffer, 0, bytes);
                tempBytes += bytes;
                downloadProgress.MoveProgress(tempBytes, "Downloading " + tempBytes + " bytes from " + size + " bytes");
            }

            downloadProgress.Close();
            localFile.Close();
            if (dataSocket.Connected)
            {
                dataSocket.Close();
            }

            ServerResponse();

            if (!(serverResponseCode == 226 || serverResponseCode == 250))
            {
                throw new IOException(serverResponseString);
            }

        }

        public MemoryStream DownloadFileFromServerFoeWeb(string serverFileName, string localFileName)
        {
            //open a file Stream 
           // FileStream localFile = new FileStream(localFileName, FileMode.Create);
            MemoryStream ms = new MemoryStream();

            // create Data Socket
            Socket dataSocket = CreateDataSocket();

            ExecuteCommand("SIZE " + serverFileName);


            string size = serverResponseString.Substring(0, serverResponseString.IndexOf("\r"));

            //send command for Downloading
            ExecuteCommand("RETR " + serverFileName);
            if (!(serverResponseCode == 150 || serverResponseCode == 125))
            {
                throw new Exception(serverResponseString);
            }

            int tempBytes = 0;    
            //Progress downloadProgress = new Progress();
            //downloadProgress.Init(size, "Downloading....");
           // downloadProgress.Show();
            // get the sended data form the Socket
            while ((bytes = dataSocket.Receive(buffer, buffer.Length, 0)) > 0)
            {
                ms.Write(buffer, 0, bytes);
                //localFile.Write(buffer, 0, bytes);
                //tempBytes += bytes;
               // downloadProgress.MoveProgress(tempBytes, "Downloading " + tempBytes + " bytes from " + size + " bytes");
            }

            //downloadProgress.Close();
           // localFile.Close();
            if (dataSocket.Connected)
            {
                dataSocket.Close();
            }

            ServerResponse();

            if (!(serverResponseCode == 226 || serverResponseCode == 250))
            {
                throw new IOException(serverResponseString);
            }

            return ms;
        }

        // disconnect to the FTP Server
        public void Close()
        {
            if (clientSocket != null)
            {
                ExecuteCommand("QUIT");
            }

            CleanUP();
        }




        private void SeperateTheDirectoriesAndFiles(string[] list)
        {
            ArrayList dir = new ArrayList();
            ArrayList file = new ArrayList();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].IndexOf("<DIR>") > 0)
                {
                    dir.Add(list[i]);
                }

                else
                {
                    file.Add(list[i]);
                }
            }

            MakeDirInfo(dir);
            MakeFileInfo(file);
            //string[] sep = new string[] { " ", "  ", "   ", "    ", "     ", "      " };


        }

        private void MakeDirInfo(ArrayList dir)
        {
            string[] strDir = (string[])dir.ToArray(Type.GetType("System.String"));
            string[] reSep;
            FtpDirectoryInfo info;
            ArrayList tempDirInfo = new ArrayList();
            for (int i = 0; i < strDir.Length; i++)
            {
                if (strDir[i] != "")
                {
                    info = new FtpDirectoryInfo();
                    // reSep = strDir[i].Split(sep, StringSplitOptions.None);
                    reSep = DirectorySplitor(strDir[i]);
                    info.creationDate = reSep[0] + " " + reSep[1];
                    info.dirName = reSep[reSep.Length - 1];
                    tempDirInfo.Add(info);
                    info = null;
                }

                directories = (FtpDirectoryInfo[])tempDirInfo.ToArray(Type.GetType("AkijFTPConnector.FtpDirectoryInfo"));

            }
        }

        private string[] DirectorySplitor(string dirInfoString)
        {
            string[] finalSplit;
            bool ysnKeyfound = false;
            string tempString = "";
            ArrayList g = new ArrayList();
            string[] reSplit = dirInfoString.Split(sep, StringSplitOptions.None);
            for (int i = 0; i < reSplit.Length; i++)
            {
                if (reSplit[i] != "" && !ysnKeyfound)
                {
                    g.Add(reSplit[i]);

                }
                else if (reSplit[i] != "")
                {
                    tempString += reSplit[i];
                    if (i != reSplit.Length - 1)
                    {
                        tempString += " ";
                    }
                }

                if ((reSplit[i].CompareTo("<DIR>")) == 0)
                {
                    ysnKeyfound = true;
                }


            }
            g.Add(tempString);
            finalSplit = (string[])g.ToArray(Type.GetType("System.String"));
            return finalSplit;
        }

        private void MakeFileInfo(ArrayList file)
        {
            string[] strFile = (string[])file.ToArray(Type.GetType("System.String"));
            string[] reSep;
            FtpFileInfo info;
            ArrayList tempFileInfo = new ArrayList();
            for (int i = 0; i < file.Count; i++)
            {
                if (strFile[i] != "")
                {
                    info = new FtpFileInfo();
                    reSep = FileSplitor(strFile[i]);
                    info.fileName = reSep[reSep.Length - 1];
                    info.size = reSep[reSep.Length - 2];
                    info.creationDate = reSep[0] + " " + reSep[1];
                    tempFileInfo.Add(info);
                    info = null;
                }

            }

            fileName = (FtpFileInfo[])tempFileInfo.ToArray(Type.GetType("AkijFTPConnector.FtpFileInfo"));
        }

        private string[] FileSplitor(string fileInfoString)
        {
            string[] finalSplit;
            bool ysnKeyFound = false;
            string tempString = "";
            ArrayList g = new ArrayList();
            string[] reSplit = fileInfoString.Split(sep, StringSplitOptions.None);
            for (int i = 0; i < reSplit.Length; i++)
            {
                if (reSplit[i] != "" && !ysnKeyFound)
                {
                    g.Add(reSplit[i]);
                    try
                    {
                        long h = long.Parse(reSplit[i]);
                        ysnKeyFound = true;
                    }
                    catch
                    {
                        ysnKeyFound = false;
                    }


                }
                else if (reSplit[i] != "")
                {
                    tempString += reSplit[i];
                    if (i != reSplit.Length - 1)
                    {
                        tempString += " ";
                    }
                }


            }




            g.Add(tempString);
            finalSplit = (string[])g.ToArray(Type.GetType("System.String"));
            return finalSplit;
        }

       
        //Creating a data Socket for transfering data to the server or from the server
        private Socket CreateDataSocket()
        {
            // take a new Socket
            Socket dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Enter into the pessive mode
            ExecuteCommand("PASV");
            if (serverResponseCode != 227)
            {
                throw new Exception(serverResponseString);
            }

            // trace the IP From the Response
            int index1 = serverResponseString.IndexOf('(');
            int index2 = serverResponseString.IndexOf(')');
            string ipData = serverResponseString.Substring(index1 + 1, index2 - index1 - 1);
          
            char[] spliptChracter = new char[]{ ',' };
            string[] ipdataParts=ipData.Split(spliptChracter);
            string ipAddress = ipdataParts[0] + "." + ipdataParts[1] + "." + ipdataParts[2] + "." + ipdataParts[3];
            int port = int.Parse(ipdataParts[4]) * 256 + int.Parse(ipdataParts[5]);

            IPEndPoint ip = new IPEndPoint(Dns.Resolve(ipAddress).AddressList[0], port);
            try
            {
                dataSocket.Connect(ip);
            }
            catch(Exception)
            {
                throw new Exception("Cannot Connect to the Server");
            }

            return dataSocket;

        }


        // common method used for renaming a directory or file at FTP Server
        private void ReNameing(string oldName, string newName)
        {
            ExecuteCommand("RNFR " + oldName);

            if (serverResponseCode != 350)
            {
                throw new IOException(serverResponseString);
            }


            ExecuteCommand("RNTO " + newName);
            if (serverResponseCode != 250)
            {
                throw new IOException(serverResponseString);
            }
        }

        // get and set the current Working Directory
        private void SetCurrentDirectorty()
        {
           ExecuteCommand("PWD ");
           if (serverResponseCode != 257)
           {
               Close();
               throw new Exception("server not responding");
           }

           currentDirectory = serverResponseString;

        }

        // Method for Executing Command to the remote server
        private void ExecuteCommand(string command)
        {
            // convert the command to byte array
            Byte[] cmdBytes = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());
            // send the command to the remote Server
            clientSocket.Send(cmdBytes, cmdBytes.Length, 0);
            //get or set the server Response
            ServerResponse();
        }

        // method for getting server Response
        private void ServerResponse()
        {

            int sizeReceived;
            Byte[] readBytes = new Byte[1024];
            sizeReceived = clientSocket.Receive(readBytes);
            serverMessage = Encoding.ASCII.GetString(readBytes, 0, sizeReceived);

            // seperates the Server Response Code and Server Response String
            serverResponseCode = Int32.Parse(serverMessage.Substring(0, 3));
            serverResponseString = serverMessage.Substring(4, serverMessage.Length - 4);


        }

        private void CleanUP()
        {
            if (clientSocket != null)
            {
                clientSocket.Close();
                clientSocket = null;
            }
            ysnLogin = false;
        }



    }
}
