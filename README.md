# Kodify CLI

A powerful command-line interface tool that streamlines development workflows by automating common tasks and generating various types of documentation and infrastructure code.

## Features

- **Changelog Generation**: Automatically generate changelogs for your projects
- **README Generation**: Create standardized README files
- **CI/CD Pipeline Generation**:
  - GitHub Actions workflows
  - GitLab CI pipelines
  - Azure DevOps pipelines
- **Infrastructure as Code**:
  - Terraform configurations
  - AWS CloudFormation templates
- **Documentation**:
  - PlantUML diagrams

## Installation

### Prerequisites

- .NET 8.0 SDK or later

### Install via .NET Tool

```bash
dotnet tool install --global Kodify.CLI
```

## Usage

```bash
kodify [command] [options]
```

### Available Commands

- `generate-changelog`: Generate a changelog from your git history
- `generate-readme`: Create a standardized README file
- `github-actions`: Generate GitHub Actions workflow files
- `gitlab-ci`: Generate GitLab CI pipeline configurations
- `azure-devops`: Generate Azure DevOps pipeline definitions
- `terraform`: Generate Terraform configuration files
- `cloudformation`: Generate AWS CloudFormation templates
- `puml`: Generate PlantUML diagrams

For detailed information about each command, use:

```bash
kodify [command] --help
```

## License

This project is licensed under the terms of the license included in the repository. See the [LICENSE](LICENSE) file for details.

