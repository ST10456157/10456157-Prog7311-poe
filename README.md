# 🚚 Global Logistics Management System (GLMS)

## 📌 Overview

The **Global Logistics Management System (GLMS)** is an ASP.NET Core MVC web application designed to manage logistics operations.
It allows users to manage **Clients**, **Contracts**, and **Service Requests** while enforcing business rules and applying software design patterns.

---

## 🎯 Features

### 👤 Client Management

* Create and view clients
* Store contact details and region
* One-to-many relationship with contracts

### 📄 Contract Management

* Link contracts to clients
* Track:

  * Start Date & End Date
  * Status (Draft, Active, Expired)
  * Service Level (Standard, Express)
* Upload and download contract documents (PDF)

### 🔧 Service Requests

* Create service requests linked to contracts
* Enforce business rule:

  * ❌ Cannot create request for inactive contracts
* Automatically calculate cost using Strategy Pattern

---


## 🚀 Usage

1. Create a **Client**
2. Create a **Contract** linked to the client
3. Upload contract document (PDF)
4. Create a **Service Request**

   * Only works if contract is **Active**
   * Cost calculated automatically



## 👨‍💻 Author

**Keshav Haripaul**
Student Number: **10456157**



This project is for academic purposes.
