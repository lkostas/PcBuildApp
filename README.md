# **PC Build Simulator**

**PC Build Simulator** is an ASP.NET Core MVC application designed to help users create custom PC builds with real-time compatibility checking, bottleneck analysis, and cost calculations. Users can experiment with different component combinations, validate compatibility, and share their builds with the community.

## **📌 Features**

* ✅ **Component Selection**: Browse and select from CPUs, GPUs, RAM, Storage, PSUs, Motherboards, Cooling, and Cases
* ✅ **Compatibility Checking**: Real-time validation for CPU/Motherboard socket compatibility and DDR4/DDR5 memory matching
* ✅ **Power Calculations**: Automatic power consumption calculations with PSU filtering based on requirements
* ✅ **Bottleneck Analysis**: Performance analysis between CPU and GPU components
* ✅ **Build Management**: Save builds, mark as public/private, and browse community builds
* ✅ **User Authentication**: Secure registration and login system with role-based access
* ✅ **Interactive Build Creator**: Step-by-step guided component selection process
* ✅ **Form Validation & Error Handling**
* ✅ **Modern UI**:
    * Bootstrap 5 responsive design
    * Professional component cards layout
    * Real-time build summary updates

## **🧰 Tech Stack**

* ASP.NET Core MVC 6.0
* C# + Entity Framework Core
* PostgreSQL Database
* Cookie-based Authentication
* Bootstrap 5 + JavaScript
* Repository/Service/DTO Pattern
* Dependency Injection

## **📁 Project Structure**

| **Folder/File** | **Purpose** |
|-----------------|-------------|
| `Controllers/` | MVC Controllers (Account, Builds, Components, Home) |
| `Data/` | Database Context, Entity Models, and Migrations |
| `DTO/` | Data Transfer Objects for API communication |
| `Services/` | Business Logic Layer (User, Build services) |
| `Repository/` | Data Access Layer with repository pattern |
| `Views/` | Razor view templates for UI |
| `wwwroot/` | Static files (CSS, JavaScript, images) |
| `Enums/` | Application enumerations |

## **⚙️ Setup Instructions**

1. **Clone the repository**
2. **Open the solution** in Visual Studio 2022 or JetBrains Rider
3. **Configure PostgreSQL**: Make sure PostgreSQL 14+ is installed
4. **Update connection string** in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=PcBuildApp;Username=youruser;Password=yourpassword"
  }
}
```
5. **Create the database**:
```sql
CREATE DATABASE PcBuildApp;
```
6. **Apply EF Core migrations**:
```bash
dotnet ef database update
```
7. **Run the application**:
```bash
dotnet run
```

### **Build and Deployment**

**Development Build:**
```bash
dotnet restore
dotnet build
dotnet run
```

**Production Build:**
```bash
dotnet build --configuration Release
dotnet publish --configuration Release --output ./publish
```

**Docker Deployment:**
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "PcBuildApp.dll"]
```

**Database Migration in Production:**
```bash
dotnet ef database update --connection "ProductionConnectionString"
```

### **Default Data**
The application includes comprehensive seed data with sample components, categories, and manufacturers for immediate testing and demonstration.