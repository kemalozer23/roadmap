# Git Cheat Sheet

## 1. Setting Up Git
- **Configure user name**  
  `git config --global user.name "Your Name"`
- **Configure email**  
  `git config --global user.email "you@example.com"`
- **View configuration**  
  `git config --list`

## 2. Starting a New Project
  `git init`
- **Clone an existing repository**  
  `git clone <url>`

## 3. Basic Commands
- **Check repository status**  
  `git status`
- **View changes**  
  `git diff`

## 4. Staging and Committing
- **Stage a specific file**  
  `git add <file>`
- **Stage all files**  
  `git add .`
- **Commit changes with a message**  
  `git commit -m "commit message"`
- **Commit all staged changes**  
  `git commit -a -m "commit message"`

## 5. Branching
- **Create a new branch**  
  `git branch <branch-name>`
- **Switch to a branch**  
  `git checkout <branch-name>`
- **Create and switch to a branch**  
  `git checkout -b <branch-name>`
- **List branches**  
  `git branch`

## 6. Merging and Rebasing
- **Merge a branch into the current branch**  
  `git merge <branch-name>`
- **Rebase the current branch onto another branch**  
  `git rebase <branch-name>`

## 7. Undoing Changes
- **Unstage a file**  
  `git reset <file>`
- **Undo the last commit (keep changes)**  
  `git reset --soft HEAD~1`
- **Undo the last commit (discard changes)**  
  `git reset --hard HEAD~1`
- **Revert a specific commit**  
  `git revert <commit-hash>`

## 8. Remote Repositories
- **Add a remote repository**  
  `git remote add origin <url>`
- **View remote repositories**  
  `git remote -v`
- **Push changes to a remote repository**  
  `git push origin <branch-name>`
- **Pull changes from a remote repository**  
  `git pull origin <branch-name>`
- **Fetch changes from a remote repository**  
  `git fetch origin`

## 9. Viewing Commit History
- **View commit history**  
  `git log`
- **View a specific file’s commit history**  
  `git log <file>`
- **View changes in each commit**  
  `git log -p`

## 10. Stashing
- **Stash changes**  
  `git stash`
- **View stash list**  
  `git stash list`
- **Apply the last stash**  
  `git stash apply`
- **Apply a specific stash**  
  `git stash apply stash@{n}`

## 11. Tagging
- **Create a new tag**  
  `git tag <tag-name>`
- **Push a tag to the remote**  
  `git push origin <tag-name>`
- **List all tags**  
  `git tag`

## 12. Other Useful Commands
- **Show a summary of commit history as a graph**  
  `git log --oneline --graph --all`
- **Show details of a commit**  
  `git show <commit-hash>`
- **Delete a branch**  
  `git branch -d <branch-name>`
- **Delete a remote branch**  
  `git push origin --delete <branch-name>`