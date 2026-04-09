using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Media;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Speech.Synthesis;

public class Program
{
    public static void Main(string[] args)
    {

//using Speech to translate text into a voice

        SpeechSynthesizer voice=new SpeechSynthesizer();

//displaying the ASCII art
        ImageDisplay();

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Blue;

        Console.WriteLine("hello welcome to the cybersecurity awareness bot.");
        Console.WriteLine("I'm here to help you to stay safe online. what is your name?");

//using the speech sythesizer to greet

        voice.Speak("hello welcome to the cybersecurity awareness bot.");
        voice.Speak("I'm here to help you to stay safe online. what is your name?");

        Console.ResetColor();
        Console.WriteLine(" ");

//calling the UserInteraction to prompt the user there name

        string user = UserInteraction();

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Blue;

//personalizing the respond with the user name
//
        Console.WriteLine("CHATBOT");
        Console.WriteLine("Nice to meet you "+user);
        Console.WriteLine("how can i help you "+user+" ?");

        voice.Speak("nice to meet you " + user);
        voice.Speak("how can i help you " + user);

        Console.ResetColor();
        Console.WriteLine(" ");

//keeping the chat consistant by using boolean
//by saying bye or thanks the application will exit

        bool chatconsistency = true;

        while (chatconsistency ==true)
        {

//calling the method userResponds to input and interact with the chatbot base on cybersecurity

            string interactor = UseResponds(user);

//calling the RespondSystem to reach out the dictionary that contain INFO about cybersecurity
            String chatbot = RespondSystem(interactor);

            

            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine("CHATBOT");
            Console.WriteLine(chatbot);

            voice.Speak(chatbot);

            Console.ResetColor();
           


        }



    }

    //displaying an ASCII Art
    static void ImageDisplay()
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(@"                            _______
                          _/       \_
                         / |       | \
                        /  |__   __|  \
                       |__/((o| |o))\__|
                       |      | |      |
                       |\     |_|     /|
                       | \           / |
                        \| /  ___  \ |/
                         \ | / _ \ | /
                          \_________/
                           _|_____|_
                          |         |
====================================================================================
             ██████╗██╗   ██╗██████╗ ███████╗██████╗ 
            ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗
            ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝
            ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗
            ╚██████╗   ██║   ██████╔╝███████╗██║  ██║
             ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝
====================================================================================
   ███████╗███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗
   ██╔════╝██╔════╝██╔════╝██║   ██║██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝
   ███████╗█████╗  ██║     ██║   ██║██████╔╝██║   ██║    ╚████╔╝ 
   ╚════██║██╔══╝  ██║     ██║   ██║██╔══██╗██║   ██║     ╚██╔╝  
   ███████║███████╗╚██████╗╚██████╔╝██║  ██║██║   ██║      ██║   
   ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝
====================================================================================
                            Awareness Assistant
====================================================================================

");
        Console.ResetColor();
        Console.WriteLine("  ");
    }

   

  
    //allows users to input there names
    static String UserInteraction()
    {
        Console.WriteLine(" ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.BackgroundColor = ConsoleColor.Green;

        Console.WriteLine("PLEASE ENTER YOUR NAME: ");
        string input = Console.ReadLine().ToUpper();

        Console.ResetColor();

        Console.WriteLine(" ");
        return input;
    }

    //personalizing and interacting with the chatbot
    static String UseResponds(string user)
    {
        Console.WriteLine(" ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.BackgroundColor = ConsoleColor.Green;

        Console.WriteLine(user);
        string userrespoinds = Console.ReadLine().ToLower().Trim();

        Console.ResetColor();
        Console.WriteLine(" ");

        if (userrespoinds.Contains("?"))
        {

        }
        else
        {
            userrespoinds = userrespoinds + "?";
        }

//if statement that checks if the user want to exits the application

        if(userrespoinds.Contains("bye") ||userrespoinds.Contains("thanks") || userrespoinds.Contains("thank you") || userrespoinds.Contains("exit"))
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine(" ");
            Console.WriteLine("CHATBOT");
            Console.WriteLine("BYE "+user+" have a nice day");

            Console.ResetColor();

            System.Environment.Exit(0);

        }

        return userrespoinds;
    }

//dictionary is used to search the users responds then founds the corresponding then it responds to the user 
    static String RespondSystem(string interactor)
    {
        string respond=" ";

        Dictionary<string, string> results = new Dictionary<string, string>()
{
    // General Cybersecurity questions

    {"how are you?","I'm good. Thanks for asking. How can i help you?"},

    {"hi?","Hello!! Welcome to the Cybersecurity Awareness Bot. how cam i help you"},

    {"hey?","Hello!! Welcome to the Cybersecurity Awareness Bot. how cam i help you"},


    {"cybersecurity?","Cybersecurity is the practice of protecting systems, networks, and data from digital attacks."},

    {"password?","A password is a secret word or phrase used to access an account or system."},

    {"phishing?","Phishing is a scam where attackers trick users into giving sensitive information."},

    {"malware?","Malware is harmful software designed to damage or access systems without permission."},

    {"ransomware?","Ransomware is malware that locks files and demands payment to unlock them."},

    {"virus?","A virus is a type of malware that spreads by attaching itself to files."},

    {"worm?","A worm is malware that spreads automatically through networks."},

    {"trojan?","A Trojan is malware disguised as legitimate software."},

    {"firewall?","A firewall is a system that blocks unauthorized access to or from a network."},

    {"encryption?","Encryption is the process of converting data into a secure code."},

    {"decryption?","Decryption is converting encrypted data back into readable form."},

    {"authentication?","Authentication is the process of verifying a user's identity."},

    {"authorization?","Authorization determines what a user is allowed to access."},

    {"multi factor authentication?","It is a security process that requires multiple methods to verify identity."},

    {"two factor authentication?","It is a type of authentication using two verification methods."},

    {"data breach?","A data breach is when sensitive information is accessed without permission."},

    {"hacker?","A hacker is a person who gains unauthorized access to systems."},

    {"ethical hacking?","Ethical hacking is legal hacking used to find and fix security weaknesses."},

    {"spyware?","Spyware is malware that secretly collects user information."},

    {"adware?","Adware is software that displays unwanted advertisements."},

    {"keylogger?","A keylogger records keystrokes to capture sensitive information."},

    {"botnet?","A botnet is a network of infected computers controlled by an attacker."},

    {"ddos attack?","A DDoS attack overwhelms a system with traffic to make it unavailable."},

    {"vpn?","A VPN is a secure connection that protects your internet activity."},

    {"https?","HTTPS is a secure version of HTTP that encrypts web traffic."},

    {"http?","HTTP is a protocol used to transfer data over the internet."},

    {"secure website?","A secure website uses encryption to protect user data."},

    {"identity theft?","Identity theft is stealing personal information for fraud."},

    {"social engineering?","Social engineering tricks people into revealing confidential information."},

    {"cyberattack?","A cyberattack is an attempt to damage or access systems illegally."},

    {"cyber threat?","A cyber threat is a potential danger to systems or data."},

    {"antivirus?","Antivirus software detects and removes malicious programs."},

    {"software update?","A software update fixes bugs and security vulnerabilities."},

    {"backup?","A backup is a copy of data stored for recovery."},

    {"cloud security?","Cloud security protects data stored online."},

    {"network security?","Network security protects computer networks from threats."},

    {"information security?","Information security protects all forms of data."},

    {"public wi-fi?","Public Wi-Fi is a shared internet connection that may be insecure."},

    {"private network?","A private network is restricted and secure from public access."},

    {"router?","A router directs internet traffic between devices."},

    {"ip address?","An IP address identifies a device on a network."},

    {"domain name?","A domain name is the address of a website."},

    {"spam?","Spam is unwanted or harmful messages sent online."},

    {"scam?","A scam is a fraudulent scheme to steal money or information."},

    {"cybercrime?","Cybercrime is illegal activity done using computers or the internet."},

    {"digital footprint?","A digital footprint is the data you leave behind online."},

    {"privacy?","Privacy is the protection of personal information."},

    {"security policy?","A security policy is a set of rules to protect systems and data."},

    {"incident response?","Incident response is how organizations handle cyberattacks."},

    {"risk management?","Risk management is identifying and reducing cybersecurity risks."},

    {"strong password?","Use at least 12 characters including letters, numbers, and symbols." },

    {"password manager?","A password manager securely stores and generates strong passwords." },

    {"weak password?","Short passwords, common words, or personal information make passwords weak." },

 // Additional question that might be asked

    {"what is your purpose?","The chatbot teaches users about cyber threats such as phishing, malware, hacking, and identity theft. It also encourages good cybersecurity practices like strong passwords and avoiding suspicious links."},

    {"purpose?","The chatbot teaches users about cyber threats such as phishing, malware, hacking, and identity theft. It also encourages good cybersecurity practices like strong passwords and avoiding suspicious links."},

    {"what can i ask you about?","You can ask me general cybersecurity questions and how to stay safe online."},

    {"about?","You can ask me general cybersecurity questions and how to stay safe online."},

    {"what is cybersecurity?","Cybersecurity is the practice of protecting computers, networks, systems, and data from cyberattacks and unauthorized access."},

    {"why is cybersecurity important?","Cybersecurity protects personal information, financial data, and business systems from being stolen or damaged."},

    {"important?","Cybersecurity protects personal information, financial data, and business systems from being stolen or damaged." },

    {"what are the most common cyber threats today?","Common cyber threats include phishing, malware, ransomware, identity theft, and social engineering attacks."},

    {"how can i protect my personal information online?","Use strong passwords, enable two-factor authentication, avoid suspicious links, and only share information on trusted websites."},

    {"what is the difference between cybersecurity and information security?","Cybersecurity protects digital systems and networks, while information security protects all types of information."},

    {"what is a cyberattack?","A cyberattack is an attempt to access, damage, or steal data from a computer system or network."},

    {"who are hackers and what do they do?","Hackers try to gain unauthorized access to computer systems. Some are criminals while others help organizations find security weaknesses."},

    {"what are the basic principles of cybersecurity?","The main principles are confidentiality, integrity, and availability of data."},

    {"how do companies protect their data from cyber threats?","Companies use firewalls, encryption, antivirus software, security policies, and employee training."},

    {"what are the biggest cybersecurity risks for individuals?","Weak passwords, phishing emails, unsafe downloads, and unsecured public Wi-Fi."},


    // Password and Authentication

    {"how do i create a strong password?","Use at least 12 characters including letters, numbers, and symbols."},

    {"why should i avoid using the same password for multiple accounts?","If one account gets hacked, attackers may access your other accounts."},

    {"what is multi factor authentication?","It requires more than one way to verify your identity, like a password and a code sent to your phone."},

    {"why is two factor authentication important?","It adds an extra layer of security and makes hacking more difficult."},

    {"how often should i change my password?","You should change important passwords every 3 to 6 months."},

    {"what is a password manager?","A password manager securely stores and generates strong passwords."},

    {"is it safe to store passwords in my browser?","It can be convenient but a dedicated password manager is usually safer."},

    {"what makes a password weak?","Short passwords, common words, or personal information make passwords weak."},

    {"what should i do if my password is hacked?","Change it immediately and enable two-factor authentication."},

    {"how can i remember strong passwords?","Use passphrases or store them in a password manager."},



    // Phishing

    {"what is phishing?","Phishing is a scam used to trick people into revealing sensitive information."},

    {"how can i identify a phishing email?","Look for suspicious links, unknown senders, poor grammar, or urgent requests."},

    {"what should i do if i receive a suspicious email?","Do not click links or attachments. Delete or report the email."},

    {"can phishing happen through sms messages?","Yes, it is called smishing."},

    {"what is spear phishing?","A targeted phishing attack aimed at a specific person or organization."},

    {"how do hackers use phishing to steal information?","They send fake emails or create fake websites to trick users."},

    {"what is a fake website and how can i identify one?","Check the website address, spelling, and if it uses HTTPS."},

    {"what should i do if i accidentally click a phishing link?","Close the page and scan your device with antivirus software."},



    // Malware

    {"what is malware?","Malware is malicious software designed to harm or access systems without permission."},

    {"what is the difference between a virus worm and trojan?","A virus spreads through files, a worm spreads through networks, and a Trojan hides inside legitimate software."},

    {"how can malware infect my computer?","Through infected downloads, email attachments, or unsafe websites."},

    {"what is ransomware?","Ransomware locks your files and demands payment to unlock them."},

    {"what should i do if my computer gets infected with malware?","Disconnect from the internet and run antivirus software."},

    {"how can antivirus software protect my device?","It scans and removes malicious programs."},

    {"can smartphones get viruses?","Yes, especially from unsafe apps or downloads."},

    {"how can i safely download files from the internet?","Download only from trusted websites."},



    // Internet Safety

    {"is public wi-fi safe to use?","Public Wi-Fi can be risky. Avoid accessing sensitive accounts."},

    {"how can i stay safe on social media?","Use privacy settings and avoid sharing personal information."},

    {"what personal information should i avoid sharing online?","Avoid sharing addresses, ID numbers, passwords, or bank details."},

    {"how can hackers use social media to attack people?","They gather personal information for scams or phishing."},

    {"what are privacy settings and why are they important?","They control who can see your information online."},

    {"how can i protect my identity online?","Use strong passwords and limit personal information sharing."},



    // Device Security

    {"how can i secure my home wifi network?","Use a strong password and change the router default password."},

    {"why should i update my software regularly?","Updates fix security vulnerabilities."},

    {"what is a firewall?","A firewall monitors network traffic and blocks threats."},

    {"how do i know if my device has been hacked?","Signs include slow performance, unknown apps, or strange pop-ups."},

    {"what should i do if my phone is stolen?","Lock the device remotely and report it to your service provider."},

    {"how can i protect my laptop when using it in public?","Avoid public Wi-Fi and lock your device when not using it."},



    // Best Practices

    {"what are the best cybersecurity habits everyone should follow?","Use strong passwords, update software, and avoid suspicious links."},

    {"what should i do if i become a victim of a cyberattack?","Change passwords, scan devices, and report the incident."},

    {"what is identity theft?","Identity theft is when someone uses your personal information without permission."},

    {"how can i avoid identity theft?","Protect your personal information and use strong passwords."},

    {"what is a secure website?","A secure website uses HTTPS encryption."},

    {"what does https mean?","HTTPS means HyperText Transfer Protocol Secure."},

    {"what should i do if i click a suspicious link?","Close it and run antivirus software."},

    {"what is social engineering?","A technique used to manipulate people into revealing confidential information."},

    {"why should i lock my computer?","It prevents unauthorized access to your data."},

    {"what is a vpn?","A VPN protects your internet connection and privacy."},

    {"is it safe to download free software?","Only download from trusted websites."},

    {"what is a data breach?","A data breach happens when sensitive information is stolen."},

    {"how do i know if a website is fake?","Check the URL, spelling, and HTTPS."},

    {"what is encryption?","Encryption converts data into secure code."},

    {"why is cybersecurity awareness important?","It helps people recognize cyber threats."},

    {"what is spyware?","Spyware secretly collects information without permission."},

    {"why should i back up my data?","Backups protect files from loss or malware."},

    {"what is a cyber threat?","Any activity that can harm systems or data."},

    {"how can i protect my wifi network?","Use a strong password and encryption."},

    {"what is cybercrime?","Illegal activity done using computers or the internet."},

    {"how can i stay safe when shopping online?","Use trusted websites and secure payment methods."}
};

        if (results.ContainsKey(interactor))
        {
            respond = results[interactor];
        }
//a helpful errow message
        else
        {
            respond = "I didn't quite understand that could you rephrase?";
        }

            return respond;
    }


}