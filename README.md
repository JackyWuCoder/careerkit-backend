# CareerKit Backend

**CareerKit Backend** – API service for the CareerKit platform.

> A modular backend for generating tailored cover letters and supporting future job-seeking tools.

This project provides the core logic for the CareerKit platform, handling API requests, AI integration, and response formatting. It is designed to scale as additional job search–related services are added over time.

---

## 🚀 Tech Stack

- ASP.NET Core Web API
- C#
- RESTful architecture
- Planned: OpenAI / AI model integration
- Planned: In-memory or database-backed rate limiting

---

## 🛠 Features

- Minimal API scaffold (MVP phase)
- Modular structure for scalable service logic
- Planned: AI-powered cover letter generation
- Planned: Rate limiting for API requests
- Planned: Optional database integration for persistence/logging

---

## 📝 Git Commit Message Format

**Using Conventional Commits**:

`<type>: <short message>`

| Type        | Purpose                                        |
|-------------|------------------------------------------------|
| `feat`      | New feature                                    |
| `fix`       | Bug fix                                        |
| `hotfix`    | Urgent fix on production                       |
| `docs`      | Documentation changes                          |
| `style`     | Code formatting or naming convention updates   |
| `chore`     | Maintenance/setup work                         |
| `refactor`  | Code restructuring (no feature change)         |
| `test`      | Add or modify tests                            |
| `ci`        | CI configuration changes (GitHub Actions, etc.)|
| `exp`       | Experimental code/features (may be removed)    |

---

## 🗂 Status

> MVP in progress – initializing backend structure and preparing for AI integration and frontend connectivity.

### 🔁 Git Workflow & Branch Strategy

This project follows a **real-world team simulation workflow** with the following conventions:

---

#### 📌 Branching Strategy

| Branch      | Purpose                                                                        |
|-------------|--------------------------------------------------------------------------------|
| `main`      | 🟢 Production-ready code only. Protected branch with enforced reviews.        |
| `dev`       | 🛠️ Active development/integration branch. All features are merged here first. |
| `feat/*`    | ✨ Feature branches for new additions.                                        |
| `fix/*`     | 🐛 Bug fixes.                                                                 |
| `hotfix/*`  | 🚨 Emergency patches (applied directly to `main`, if needed).                 |

---

#### ✅ Pull Request Rules

- All changes are introduced via **pull requests (PRs)**.
- **`main` branch:**
  - Requires PRs with at least **1 approving review**.
  - PR authors **cannot approve their own PRs**.
  - CI (build + lint) must pass.
  - Force pushes are **blocked**.
- **`dev` branch:**
  - PRs are encouraged, but direct pushes are allowed for speed.
  - CI is run on all pushes and PRs.
  - No required approvals.

---

#### 🚦 Merge Method

Only **squash and merge** is enabled to maintain a clean, linear commit history.

---

#### 🛡️ Protected Branches

| Branch | Protection Rules |
|--------|------------------|
| `main` | ✅ PRs only, ✅ CI required, ✅ 1 approval, ✅ No force push |
| `dev`  | ✅ CI optional, 🚫 Review required, ✅ PR preferred |