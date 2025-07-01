# Stopwatch Application

A simple Stopwatch application built using C# and Windows Forms. This application allows users to Start, Pause, Resume, Reset, and Stop the timer while displaying elapsed time in the format `hh:mm:ss`.

## Features

* Start the stopwatch from `00:00:00`.
* Pause the timer to temporarily halt the count.
* Resume from the paused time.
* Reset to clear the timer.
* Stop to end the current session.
* Clean and intuitive Windows Forms interface.
* Accurate real-time updates every second.

## Technologies Used

* C#
* .NET Framework
* Windows Forms

## Project Structure

```
GROUP-CODING-SESSION/
│
├── StopwatchApp/             
│   ├── Form1.cs              # Handles UI logic and events
│   ├── Form1.Designer.cs     # Auto-generated UI components
│   ├── Program.cs            # Application entry point
│   └── Form1.resx            # Resources for the form
│
├── bin/                      # Compiled binaries
├── obj/                      # Intermediate build files
├── screenshots/              # UI screenshots
├── README.md                 # Project documentation
├── StopwatchApp.csproj       # C# project configuration
└── StopwatchApp.sln          # Visual Studio solution file
```

## Getting Started

### Prerequisites

* Visual Studio or Visual Studio Code with C# Dev Kit extension
* .NET Framework installed on your machine

### Steps to Run

1. **Clone the repository**

   ```
   git clone https://github.com/Malongmak/Group-Coding-Session.git
   ```

2. **Open the Solution**
   Open the `StopwatchApp.sln` file using Visual Studio.

3. **Restore NuGet Packages**
   If prompted with a NuGet error:

   * Open the terminal and run:

     ```
     dotnet restore
     ```

   Or use **Tools > NuGet Package Manager > Manage NuGet Packages** to restore them.

4. **Build the Application**
   Navigate to `Build > Build Solution` or press `Ctrl+Shift+B`.

5. **Run the Application**
   Start debugging with `F5` or go to `Debug > Start Debugging`.

## Usage

* Click **Start** to begin the timer.
* Use **Pause** and **Resume** to control the session.
* Click **Stop** to end.
* Click **Reset** to clear the time.

## Authors

This project was developed collaboratively by:

* Daniel Iryivuze
* Divine Uwase
* Joshua Malongmak

GitHub Repository: [https://github.com/Malongmak/Group-Coding-Session](https://github.com/Malongmak/Group-Coding-Session)
