# C# Packet Capture Tool

## 🚀 Overview
This **Packet Capture Tool** is a network traffic analyzer built using **C#**. It allows users to capture live packets from network interfaces, apply custom **packet filters**, and analyze **TCP, UDP, and ICMP** traffic in real-time.

## 🎯 Features
- 📡 **Real-Time Packet Capture**: Captures network packets from selected network interfaces.
- 🔍 **User-Defined Filtering**: Supports custom packet filtering using **BPF expressions** (e.g., `tcp port 80`).
- 🖥 **Multi-Protocol Support**: Extracts and displays **IP, TCP, UDP** packet details.
- 🚀 **Error Handling**: Handles invalid filters and device selection errors gracefully.

## 🛠 Installation
1. Clone this repository:
   ```sh
   git clone https://github.com/your-repo/PacketCaptureTool.git
   cd PacketCaptureTool
   ```
2. Install the required NuGet package:
   ```sh
   dotnet add package SharpPcap
   ```
3. Open the project in **Visual Studio** or **VS Code**.
4. Build and Run the application.

## ⚙ Usage
1. **Run the program** and select a network interface.
2. **Enter a filter** (or leave blank to capture all packets).
3. **View captured packets** in the console.
4. **Press Enter** to stop capturing.

### 📌 Example User Input
```
Enter device index to capture: 1
Enter your packet filter (e.g., 'tcp port 80', 'icmp', 'src host 192.168.1.1'): tcp port 443
✅ Applied filter: tcp port 443
🎯 Listening on Wi-Fi Adapter...
📡 TCP Packet: 192.168.1.10:53211 -> 142.250.180.206:443
🔴 Press Enter to stop...
```

## 🔎 Common Packet Filters
| **Filter**                | **Description** |
|---------------------------|----------------|
| `tcp`                     | Capture only TCP packets |
| `udp`                     | Capture only UDP packets |
| `icmp`                    | Capture only ICMP (ping) packets |
| `port 80`                 | Capture HTTP traffic |
| `tcp port 443`            | Capture HTTPS traffic |
| `src host 192.168.1.1`    | Capture traffic from a specific IP |
| `dst host 8.8.8.8`        | Capture traffic going to Google DNS |

## 🔥 Future Enhancements
- 📁 **Save Captured Packets** to a log or PCAP file.
- 📊 **Graphical UI** to visualize real-time network traffic.
- 🛑 **Alert System** for suspicious packets.
- 🤖 **AI-based Packet Analysis** to detect anomalies.

## 🤝 Contributing
Feel free to fork this repository, create a feature branch, and submit a pull request! 🎉

## 📜 License
This project is licensed under the **MIT License**.

---

🚀 Happy Coding & Packet Capturing! 🚀

