# ScrTableGPT
![Screenshot 2024-11-09 at 1 46 07 AM](https://github.com/user-attachments/assets/430b2f14-b29c-4052-8a72-d54c8fad70db)


ScrTableGPT is an innovative solution designed to tackle the absence of standardized timetable formats in Chinese educational institutions, while seamlessly integrating with digital calendar systems.  
ScrTableGPT 是一个创新的解决方案，旨在解决中国教育机构中缺乏标准化课表格式的问题，同时无缝集成数字日历系统。

This project leverages advanced machine learning techniques, specifically large language models (LLMs), to transform Excel-based timetables into markdown and iCalendar formats, thus streamlining the digitalization process.  
该项目利用机器学习——大型语言模型（LLM），将基于 Excel 的课表转换为 markdown 和 iCalendar 格式，从而简化数字化过程。

## 🏗️ Project Architecture  
## 🏗️ 项目架构

The architecture of ScrTableGPT is meticulously organized into several core components, each fulfilling a distinct role:  
ScrTableGPT 的架构精心组织成几个核心组件，每个组件都扮演着不同的角色：

- **Program.cs**: Serves as the primary entry point of the application, orchestrating the workflow from file input to the conversion of data into markdown and iCalendar formats.  
  **Program.cs**：作为应用程序的主要入口，协调从文件输入到数据转换为 markdown 和 iCalendar 格式的工作流程。

- **TableTools.cs**: Implements sophisticated algorithms to convert Excel files into markdown format, ensuring data integrity and readability.  
  **TableTools.cs**：实现复杂的算法，将 Excel 文件转换为 markdown 格式，确保数据的完整性和可读性。

- **CalendarTools.cs**: Utilizes the iCal.Net library to convert structured data into iCalendar format, facilitating seamless integration with calendar applications.  
  **CalendarTools.cs**：利用 iCal.Net 库将结构化数据转换为 iCalendar 格式，促进与日历应用程序的无缝集成。

- **TableOutputTools.cs**: Transforms markdown strings into a visually appealing table format for console display, enhancing user interaction.  
  **TableOutputTools.cs**：将 markdown 字符串转换为视觉上吸引人的表格格式以在控制台显示，增强用户交互。

- **LMTools.cs**: Interfaces with a state-of-the-art language model API to process markdown content and generate structured, machine-readable responses.  
  **LMTools.cs**：与最先进的语言模型 API 接口，处理 markdown 内容并生成结构化的机器可读响应。

- **HttpListenerTools.cs**: Establishes an HTTP listener using .NET's networking capabilities to serve the generated iCalendar data, enabling easy access and distribution.  
  **HttpListenerTools.cs**：使用 .NET 的网络功能建立 HTTP 监听器，以提供生成的 iCalendar 数据，便于访问和分发。

- **Models/LMResponseModel.cs**: Defines robust data structures to model the response from the language model, ensuring compatibility and scalability.  
  **Models/LMResponseModel.cs**：定义强大的数据结构以建模语言模型的响应，确保兼容性和可扩展性。

- **Data.cs**: Contains essential constants and configuration data, including API keys and model identifiers, centralizing configuration management.  
  **Data.cs**：包含基本的常量和配置数据，包括 API 密钥和模型标识符，集中管理配置。

## 🤖 Default Model  
## 🤖 默认模型

The project employs the `llama-3.2-90b-text-preview` model, a cutting-edge large language model, to process markdown content and generate structured data outputs.  
该项目采用 `llama-3.2-90b-text-preview` 模型，这是一种尖端的大型语言模型，用于处理 markdown 内容并生成结构化数据输出。

This model is configured with specific parameters that are hardcoded within the application to optimize its performance for timetable data interpretation:  
该模型配置了特定的参数，这些参数在应用程序中是硬编码的，以优化其对课表数据解释的性能：

- **Temperature**: Set to a fixed value to control the randomness of the model's output, ensuring a balance between creativity and determinism.  
  **Temperature**：设置为固定值以控制模型输出的随机性，确保创造性和确定性之间的平衡。

- **Max Tokens**: Defined to limit the number of tokens in the model's response, ensuring concise and relevant outputs.  
  **Max Tokens**：定义为限制模型响应中的标记数量，确保输出简洁且相关。

- **Top-p (Nucleus Sampling)**: Configured to determine the cumulative probability for token selection, balancing between diversity and coherence in the output.  
  **Top-p (Nucleus Sampling)**：配置为确定标记选择的累积概率，平衡输出的多样性和连贯性。

### 📜 Prompt Configuration  
### 📜 提示词配置

The prompts used by the model are also predefined within the application, guiding the model in accurately interpreting and structuring timetable data.  
模型使用的提示词也在应用程序中预定义，指导模型准确解释和构建课表数据。

These prompts include:  
这些提示词包括：

- **Contextual Information**: Hardcoded details about the timetable, such as the format and expected output.  
  **Contextual Information**：关于课表的硬编码细节，例如格式和预期输出。

- **Specific Instructions**: Directives on how to process the data, including any formatting or structural requirements.  
  **Specific Instructions**：关于如何处理数据的指令，包括任何格式或结构要求。

- **Examples**: Sample inputs and expected outputs to clarify the task for the model.  
  **Examples**：示例输入和预期输出，以明确模型的任务。

## 📚 Third-Party Libraries  
## 📚 第三方库

ScrTableGPT integrates several third-party libraries to enhance its functionality:  
ScrTableGPT 集成了几个第三方库以增强其功能：

- **EPPlus**: Facilitates Excel file manipulation, enabling efficient data extraction and conversion.  
  **EPPlus**：促进 Excel 文件操作，实现高效的数据提取和转换。

- **GroqApiLibrary**: Provides seamless interaction with the language model API.  
  **GroqApiLibrary**：提供与语言模型 API 的无缝交互。

- **Ical.Net**: Supports the creation and manipulation of iCalendar data.  
  **Ical.Net**：支持 iCalendar 数据的创建和操作。

- **Newtonsoft.Json**: Offers robust JSON serialization and deserialization capabilities.  
  **Newtonsoft.Json**：提供强大的 JSON 序列化和反序列化功能。

- **Spectre.Console**: Enhances console output with rich formatting and interactive elements.  
  **Spectre.Console**：通过丰富的格式和交互元素增强控制台输出。

## 🚀 Usage  
## 🚀 使用方法

1. **Prerequisites**: Ensure .NET 8.0 is installed on your system.  
   **先决条件**：确保您的系统上安装了 .NET 8.0。

2. **Running the Application**:  
   **运行应用程序**：

   - Compile the project using your preferred .NET build tool.  
     使用您喜欢的 .NET 构建工具编译项目。

   - Execute the program with the path to an Excel file as an argument:  
     使用 Excel 文件的路径作为参数执行程序：

     ```bash
     dotnet run --path/to/your/excel/file.xlsx
     ```

3. **Output**:  
   **输出**：

   - The program will convert the Excel file to markdown and display it in the console.  
     程序将把 Excel 文件转换为 markdown 并在控制台中显示。

   - It will also generate an iCalendar file and start an HTTP server to serve this file.  
     它还将生成一个 iCalendar 文件并启动一个 HTTP 服务器来提供此文件。

4. **Accessing the Calendar**:  
   **访问日历**：

   - Open a web browser and navigate to `http://localhost:2952/` to download the iCalendar file.  
     打开网络浏览器并导航到 `http://localhost:2952/` 以下载 iCalendar 文件。

## 💡 Development Thought Process  
## 💡 开发思路

The development of ScrTableGPT was driven by the imperative to create a seamless, efficient workflow for converting school timetables into digital formats.  
ScrTableGPT 的开发是为了创建一个无缝、高效的工作流程，将学校课表转换为数字格式。

The project architecture was designed to ensure modularity and maintainability, with each component handling a specific aspect of the conversion process.  
项目架构旨在确保模块化和可维护性，每个组件处理转换过程的特定方面。

The integration of a large language model allows for flexible and accurate interpretation of timetable data, while the HTTP server provides a straightforward method for distributing the generated calendar files.  
大型语言模型的集成允许灵活和准确地解释课表数据，而 HTTP 服务器提供了一种简单的方法来分发生成的日历文件。

## 🗂️ Markdown Organization Structure  
## 🗂️ Markdown 组织结构

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
这种结构确保项目的每个部分都被清晰定义并易于访问，促进开发和未来的增强。
