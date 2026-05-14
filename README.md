# 🚔 Police Crime Record Bureau

A multi-role web application for managing and tracking crime records, built with ASP.NET Web Forms and SQL Server. Developed as a Major Project at UIT Kuravankonam, University of Kerala.

---

## 📋 Overview

The Police Crime Record Bureau system enables secure, role-based access to crime case data across three levels of authority — Bureau Admin, District Admin, and Police Station. It includes features like OTP-based login, file encryption, document search using Bloom filters, and TF-IDF keyword indexing.

---

## 👥 User Roles

| Role | Responsibilities |
|------|-----------------|
| **Bureau Admin** | Manage district admins, view all cases across the system |
| **District Admin** | Manage police stations within the district, oversee cases |
| **Police Station** | Register and manage crime cases, upload documents |

---

## ✨ Features

- 🔐 **Secure Login** — OTP verification and role-based access control
- 📁 **Case Management** — Add, view, update, and track crime records
- 🔒 **File Encryption** — Documents encrypted/decrypted using a custom cryptography module
- 🔍 **Smart Search** — Bloom filter-based document search with TF-IDF keyword indexing and stopword removal
- 📊 **Admin Dashboard** — Charts and stats for case overview and management
- 🏛️ **Multi-level Administration** — Bureau → District → Police Station hierarchy

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| Frontend | HTML, CSS, JavaScript, Bootstrap |
| Backend | ASP.NET Web Forms (C#) |
| Database | SQL Server |
| Algorithm | Bloom Filter, TF-IDF Matrix |
| Cryptography | Custom AES-based encryption module |

---

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2019 or later
- SQL Server (local instance)
- .NET Framework 4.6.1

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/Adithyan-7/police-crime-record-bureau.git
   ```

2. **Set up the database**
   - Open SQL Server Management Studio
   - Attach the database files from the `db/` folder:
     - `PCR_Bureau.mdf`
     - `PCR_Bureau_log.ldf`

3. **Configure Web.config**
   - Copy `Web.config.example` and rename it to `Web.config`
   - Update the connection string with your SQL Server instance details:
   ```xml
   <connectionStrings>
     <add name="DBConnection"
          connectionString="Data Source=YOUR_SERVER;Initial Catalog=PCR_Bureau;Integrated Security=True;" />
   </connectionStrings>
   ```

4. **Open and run**
   - Open `PoliceCrimeRecordBureau.csproj` in Visual Studio
   - Build the solution and run with IIS Express

---

## 📸 Screenshots

> *(Add screenshots of the login page, dashboard, and case management here)*

---

## 🎓 Project Info

- **Type:** Major Academic Project
- **Institution:** UIT Kuravankonam, University of Kerala
- **Certificate:** Academic Project Completion Certificate — Trinity Software Technologies (2026)

---

## 👨‍💻 Author

**Adithyan**
- GitHub: [@Adithyan-7](https://github.com/Adithyan-7)
- Email: adithyananil49@gmail.com
