Perioperative Assistant

A cloud‑native .NET 8 API designed to streamline perioperative workflows, built with Azure Container Apps, GitHub Actions CI/CD, and modern DevOps practices.
📌 Overview

Perioperative Assistant is a healthcare workflow automation API focused on improving perioperative efficiency, reducing friction for clinical staff, and enabling future integration with EPIC/FHIR systems.

This project demonstrates real‑world cloud engineering skills including:

    Containerization

    Azure deployment

    CI/CD automation

    SQL connectivity

    Healthcare domain modeling

    API design

    Cloud‑native architecture

🚀 Live Deployment

Azure Container Apps URL:  
https://perioperativeassistant.proudmoss-12b123ab.westus3.azurecontainerapps.io/swagger
🏗️ Architecture

    Frontend: Static HTML (placeholder for future UI)

    Backend: .NET 8 Web API

    Database: Azure SQL

    Containerization: Docker + GHCR

    Hosting: Azure Container Apps (ACA)

    CI/CD: GitHub Actions → GHCR → ACA

    Logging: Azure Log Analytics

    Secrets: Azure environment variables

✨ Features (Completed)
Cloud Infrastructure

    Azure Container Apps environment created

    Container App deployed with public ingress

    Azure SQL database provisioned

    Firewall configured for Azure services

    Environment variables configured for SQL connection

    GHCR public container image configured

    Automatic revision rollout working

Application

    .NET 8 API scaffolded and functional

    Swagger UI enabled

    Dockerfile configured for production

    Static frontend placeholder deployed

    Core models, DTOs, and controllers implemented

DevOps

    GitHub Actions CI/CD pipeline created

    Pipeline builds Docker image

    Pipeline pushes image to GHCR

    Pipeline deploys new revision to Azure Container Apps

    Indentation + YAML validation complete

    First successful CI/CD run in progress

🔧 Features (In Progress)
Cloud & DevOps

    CI/CD pipeline refinement

    Adding versioned image tags (instead of latest)

    Adding automated health checks

    Adding deployment badges to README

Application

    Expanding API endpoints

    Adding validation + error handling

    Improving data models

    Adding authentication (future)

Database

    Adding migrations for additional tables

    Seeding initial clinical workflow data

    Adding stored procedures or views (optional)

📅 Planned Enhancements (Next Steps)
Cloud Engineering

    Add staging environment

    Add automated tests in CI/CD

    Add GitHub Actions artifact retention

    Add Azure Monitor dashboards

Healthcare Integration

    EPIC/FHIR workflow integration

    HL7 event ingestion

    OR scheduling automation

    Clinical decision support hooks

Frontend

    Replace static HTML with a React or Blazor UI

    Add authentication + role-based access

    Add clinician‑friendly dashboards

🧰 Tech Stack
Area	Technology
API	.NET 8 Web API
Cloud	Azure Container Apps
Database	Azure SQL
Containerization	Docker
Registry	GitHub Container Registry (GHCR)
CI/CD	GitHub Actions
Logging	Azure Log Analytics
Future Integration	EPIC / FHIR
📦 Repository Structure
Code

PerioperativeAssistant/
│
├── Controllers/
├── DTOs/
├── Data/
├── Migrations/
├── Models/
├── Properties/
├── wwwroot/
│   └── index.html
│
├── Dockerfile
├── .dockerignore
├── PerioperativeAssistant.csproj
├── Program.cs
│
└── .github/
    └── workflows/
        └── deploy.yml

🛠️ CI/CD Pipeline Summary

The GitHub Actions workflow:

    Builds the .NET project

    Builds a Docker image

    Logs into GHCR

    Pushes the image

    Logs into Azure

    Deploys the new image to Azure Container Apps

    Rolls out a new revision automatically

This creates a fully automated cloud deployment pipeline.
📈 Status

    CI/CD: In progress (first run executing successfully)

    Cloud deployment: Operational

    API: Functional

    Next milestone: Add automated tests + versioned deployments

👤 Author

Kevin Brodersen  
Cloud Engineering • Healthcare IT • DevOps • Innovation
St. Augustine, FL
