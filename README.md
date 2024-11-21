# ScrTableGPT
![Screenshot 2024-11-09 at 1 46 07 AM](https://github.com/user-attachments/assets/430b2f14-b29c-4052-8a72-d54c8fad70db)


ScrTableGPT is an innovative solution designed to tackle the absence of standardized timetable formats in Chinese educational institutions, while seamlessly integrating with digital calendar systems. This project leverages advanced machine learning techniques, specifically large language models (LLMs), to transform Excel-based timetables into markdown and iCalendar formats, thus streamlining the digitalization process.

## 🏗️ Project Architecture

The architecture of ScrTableGPT is meticulously organized into several core components, each fulfilling a distinct role:

- **Program.cs**: Serves as the primary entry point of the application, orchestrating the workflow from file input to the conversion of data into markdown and iCalendar formats.

- **TableTools.cs**: Implements sophisticated algorithms to convert Excel files into markdown format, ensuring data integrity and readability.

- **CalendarTools.cs**: Utilizes the iCal.Net library to convert structured data into iCalendar format, facilitating seamless integration with calendar applications.

- **TableOutputTools.cs**: Transforms markdown strings into a visually appealing table format for console display, enhancing user interaction.

- **LMTools.cs**: Interfaces with a state-of-the-art language model API to process markdown content and generate structured, machine-readable responses.

- **HttpListenerTools.cs**: Establishes an HTTP listener using .NET's networking capabilities to serve the generated iCalendar data, enabling easy access and distribution.

- **Models/LMResponseModel.cs**: Defines robust data structures to model the response from the language model, ensuring compatibility and scalability.

- **Data.cs**: Contains essential constants and configuration data, including API keys and model identifiers, centralizing configuration management.

## 🤖 Default Model

The project employs the `llama-3.2-90b-text-preview` model, a cutting-edge large language model, to process markdown content and generate structured data outputs. This model is configured with specific parameters that are hardcoded within the application to optimize its performance for timetable data interpretation:

- **Temperature**: Set to a fixed value to control the randomness of the model's output, ensuring a balance between creativity and determinism.
- **Max Tokens**: Defined to limit the number of tokens in the model's response, ensuring concise and relevant outputs.
- **Top-p (Nucleus Sampling)**: Configured to determine the cumulative probability for token selection, balancing between diversity and coherence in the output.

### 📜 Prompt Configuration

The prompts used by the model are also predefined within the application, guiding the model in accurately interpreting and structuring timetable data. These prompts include:

- **Contextual Information**: Hardcoded details about the timetable, such as the format and expected output.
- **Specific Instructions**: Directives on how to process the data, including any formatting or structural requirements.
- **Examples**: Sample inputs and expected outputs to clarify the task for the model.

## 📚 Third-Party Libraries

ScrTableGPT integrates several third-party libraries to enhance its functionality:

- **EPPlus**: Facilitates Excel file manipulation, enabling efficient data extraction and conversion.
- **GroqApiLibrary**: Provides seamless interaction with the language model API.
- **Ical.Net**: Supports the creation and manipulation of iCalendar data.
- **Newtonsoft.Json**: Offers robust JSON serialization and deserialization capabilities.
- **Spectre.Console**: Enhances console output with rich formatting and interactive elements.

## 🚀 Usage

1. **Prerequisites**: Ensure .NET 8.0 is installed on your system.

2. **Running the Application**:
   - Compile the project using your preferred .NET build tool.
   - Execute the program with the path to an Excel file as an argument:
     ```bash
     dotnet run --path/to/your/excel/file.xlsx
     ```

3. **Output**:
   - The program will convert the Excel file to markdown and display it in the console.
   - It will also generate an iCalendar file and start an HTTP server to serve this file.

4. **Accessing the Calendar**:
   - Open a web browser and navigate to `http://localhost:2952/` to download the iCalendar file.

## 💡 Development Thought Process

The development of ScrTableGPT was driven by the imperative to create a seamless, efficient workflow for converting school timetables into digital formats. The project architecture was designed to ensure modularity and maintainability, with each component handling a specific aspect of the conversion process. The integration of a large language model allows for flexible and accurate interpretation of timetable data, while the HTTP server provides a straightforward method for distributing the generated calendar files.

## 🗂️ Markdown Organization Structure

```
ScrTableGPT
│
├── Program.cs
├── Tools
│   ├── TableTools.cs
│   ├── CalendarTools.cs
│   ├── TableOutputTools.cs
│   ├── LMTools.cs
│   └── HttpListenerTools.cs
├── Models
│   └── LMResponseModel.cs
├── Data.cs
└── Examples
    └── LMResponseExample.json
```

This structure ensures that each part of the project is clearly defined and easily accessible, facilitating both development and future enhancements.
