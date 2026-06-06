# Perioperative Assistant

**Azure AI-powered web application simulating Epic Optime and Anesthesia clinical workflows**

Built by Kevin Brodersen — Anesthesia Technician at Mayo Clinic.

## Overview

A production-grade C# / ASP.NET Core application designed to demonstrate how Azure cloud and AI services can support real perioperative operations. The project is inspired by my daily work using Epic Optime and Anesthesia modules in high-acuity surgical environments.

## Key Features

- Surgical case creation, scheduling, and management
- Anesthesia record documentation with validation
- AI-powered clinical note summarization and risk flagging using **Azure OpenAI**
- Document processing with **Azure Computer Vision** and **Form Recognizer**
- Predictive analytics for surgical instrument usage (GlideScope blades, etc.)
- Secure, compliant architecture (HIPAA-aligned)
- Power BI dashboard for operational insights
- Container-ready with Docker

## Technologies Used

- **Backend**: C# / ASP.NET Core 8 + Entity Framework Core
- **Database**: Azure SQL Database
- **AI/ML**: Azure AI Services (OpenAI, Computer Vision, Form Recognizer)
- **Hosting**: Azure App Service
- **Security**: Azure Key Vault, Azure AD, Private Endpoints, RBAC
- **Monitoring**: Application Insights
- **DevOps**: Docker, GitHub Actions (in progress)

## Architecture

Users (OR Staff) → ASP.NET Core Web API (Azure App Service)
                     ↓
              Azure SQL Database
                     ↓
          Azure AI Services (OpenAI + Computer Vision)
                     ↓
              Power BI Dashboard + Predictive Models

## Learning Objectives

This project was built while studying for Microsoft Azure certifications (AZ-900 completed, AI-102 and AZ-104 in progress) to bridge my clinical expertise with modern cloud and AI technologies.

## Setup & Deployment

- Deployed on Azure App Service
- Database: Azure SQL
- Live Demo: 

## Future Enhancements

- Real-time integration with Epic via FHIR or Reporting Workbench
- Advanced predictive models for case duration and resource allocation
- Full Docker + CI/CD pipeline

---

Would you like me to:
- Refine either the LinkedIn post or README?
- Add a more detailed architecture section?
- Create a follow-up post for when you add the GlideScope feature?

Let me know how you want to polish these! This is looking very professional.
