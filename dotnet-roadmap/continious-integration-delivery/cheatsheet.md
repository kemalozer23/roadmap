
# Continuous Integration & Delivery (Automation) Cheat Sheet

## GitHub Actions

### Overview
- GitHub Actions allows automating workflows directly within GitHub.
- Features:
  - Build, test, and deploy code.
  - Event-driven workflows (e.g., push, pull request, release).

### Key Components
- **Workflow**: YAML file defining automation processes.
- **Job**: Runs a series of steps on a virtual machine.
- **Step**: Individual task in a job (e.g., running a script or action).
- **Action**: Reusable automation units.

### Example: .NET Build & Test Workflow
```yaml
name: Build and Test .NET App

on:
  push:
    branches:
      - main

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
    - name: Checkout code
      uses: actions/checkout@v3

    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 6.0

    - name: Restore dependencies
      run: dotnet restore

    - name: Build application
      run: dotnet build --no-restore

    - name: Run tests
      run: dotnet test --no-build --verbosity normal
```

### Key Actions
- **actions/checkout**: Checks out repository code.
- **actions/setup-dotnet**: Configures .NET environment.
- **actions/upload-artifact**: Uploads build/test artifacts.
- **actions/deploy-to-azure**: Deploys applications to Azure.

### Secrets Management
- Store sensitive data (e.g., API keys, credentials) in **Settings > Secrets**.
- Access secrets using `${{ secrets.SECRET_NAME }}`.

---

## Azure Pipelines

### Overview
- Azure Pipelines is a CI/CD service part of Azure DevOps.
- Features:
  - Builds, tests, and deploys across multiple platforms and languages.
  - Integration with GitHub, Azure Repos, and external repositories.

### Key Components
- **Pipeline**: Definition of automation steps (YAML or Classic Editor).
- **Agent**: Executes pipeline jobs (Microsoft-hosted or self-hosted).
- **Stage**: Group of related jobs (e.g., Build, Test, Deploy).
- **Job**: Set of steps that execute on the same agent.

### Example: YAML Pipeline for .NET Build & Deploy
```yaml
trigger:
- main

pool:
  vmImage: 'windows-latest'

variables:
  buildConfiguration: 'Release'

stages:
- stage: Build
  jobs:
  - job: BuildJob
    steps:
    - task: UseDotNet@2
      inputs:
        packageType: 'sdk'
        version: '6.0.x'
    - task: DotNetCoreCLI@2
      inputs:
        command: 'restore'
        projects: '**/*.csproj'
    - task: DotNetCoreCLI@2
      inputs:
        command: 'build'
        projects: '**/*.csproj'
        arguments: '--configuration $(buildConfiguration)'
    - task: DotNetCoreCLI@2
      inputs:
        command: 'test'
        projects: '**/*.csproj'

- stage: Deploy
  dependsOn: Build
  jobs:
  - job: DeployJob
    steps:
    - task: AzureWebApp@1
      inputs:
        azureSubscription: 'YourAzureSubscription'
        appType: 'webApp'
        appName: 'YourAppName'
        package: '$(System.DefaultWorkingDirectory)/path/to/package.zip'
```

### Key Tasks
- **UseDotNet@2**: Configures .NET SDK environment.
- **DotNetCoreCLI@2**: Executes .NET CLI commands (restore, build, test).
- **AzureWebApp@1**: Deploys a web application to Azure App Service.

### Key Features
- **Triggers**: Define when pipelines run (e.g., on code push, PR).
- **Environments**: Manage approvals and gates for deployments.
- **Variables**: Define and reuse key-value pairs in pipelines.

---

## CI/CD Best Practices
- Automate unit tests and integration tests.
- Use consistent naming for workflows and pipelines.
- Secure secrets and credentials in a vault or secret manager.
- Enable notifications for build/test failures.
- Maintain versioned YAML files for reproducible builds.