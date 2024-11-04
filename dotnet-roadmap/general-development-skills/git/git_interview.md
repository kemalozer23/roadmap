# Git Interview Questions and Answers

## Junior Developer

1. **What is Git, and why do we use it?**  
   Git is a version control system used to track changes in source code. It allows multiple developers to work on a project simultaneously without overwriting each other’s work and enables tracking changes, reverting to previous versions, and managing code history.

2. **Explain the difference between `git clone`, `git pull`, and `git fetch`.**  
   - `git clone` copies an entire repository, including its history, to your local machine.
   - `git pull` fetches and integrates changes from a remote repository into your local branch.
   - `git fetch` retrieves changes from a remote repository but doesn’t integrate them into your local branch until you merge.

3. **How do you initialize a Git repository in a new or existing project?**  
   Use `git init` in the project’s root directory to create a new Git repository. This creates a `.git` folder that tracks changes.

4. **What does `git status` do, and when would you use it?**  
   `git status` shows the current state of the working directory and staging area, including untracked, modified, and staged files. It’s useful for checking the status of your files before committing.

5. **Explain the difference between `git add`, `git commit`, and `git push`.**  
   - `git add` stages changes to be committed.
   - `git commit` records the staged changes with a message in the local repository.
   - `git push` uploads commits to a remote repository.

6. **How would you create a new branch? Why might branching be useful?**  
   Use `git branch <branch-name>` to create a branch. Branching allows you to develop features in isolation from the main codebase, making it easier to manage and test changes without affecting the main branch.

7. **What does `git merge` do, and what happens if there are conflicts?**  
   `git merge` integrates changes from one branch into another. If there are conflicting changes, Git will prompt you to resolve them before completing the merge.

8. **Describe how you would undo a commit. What does `git reset` do?**  
   `git reset` can undo changes. For example, `git reset --soft` keeps changes staged, while `--hard` discards them. `git reset HEAD~1` undoes the latest commit.

9. **Explain what a “commit” is and why commits should have meaningful messages.**  
   A commit is a snapshot of changes in a repository. Meaningful commit messages help others understand what changes were made and why, making collaboration easier.

10. **What is a `.gitignore` file? How does it work?**  
    A `.gitignore` file specifies which files Git should ignore (e.g., build files, secrets). Files listed in `.gitignore` are not tracked by Git.

---

## Mid-Level Developer

1. **Explain the difference between `git reset --soft`, `--mixed`, and `--hard`. When would you use each?**  
   - `--soft` keeps changes staged.
   - `--mixed` unstages changes but keeps them in the working directory.
   - `--hard` discards all changes. Use each option based on how much of the changes you want to keep.

2. **How do you handle merge conflicts? Can you describe a time when you dealt with one?**  
   Merge conflicts occur when changes in different branches clash. To resolve them, open the files in conflict, decide which changes to keep, and then commit the resolved code.

3. **What is the difference between `git merge` and `git rebase`? When would you use each?**  
   - `git merge` combines changes from branches with a new merge commit.
   - `git rebase` replays commits from one branch onto another without merge commits. Use `merge` for clarity and `rebase` for a cleaner history.

4. **How would you create and apply a Git tag? What’s the purpose of tagging in Git?**  
   Create a tag with `git tag <tag-name>` and push it with `git push origin <tag-name>`. Tags mark important points in history, like releases.

5. **Explain what `git stash` does. How might it be useful in a development workflow?**  
   `git stash` temporarily saves changes without committing them, useful for switching branches or pulling updates without losing work.

6. **What is a remote repository, and how do you link one to your local repository?**  
   A remote repository (like GitHub) stores your code online. Use `git remote add origin <url>` to link a local repository to a remote one.

7. **How would you go about removing a file from a commit after it has already been pushed?**  
   Use `git rm <file>` to delete it, commit, and then push. Or use `git filter-branch` to remove it from history if needed.

8. **Explain the purpose of `git cherry-pick`. When might you use it?**  
   `git cherry-pick <commit-hash>` applies a specific commit from one branch to another, helpful for applying bug fixes without merging entire branches.

9. **Describe how to squash commits. Why would you want to squash commits in a project?**  
   Squash commits during a rebase (e.g., `git rebase -i`) to combine multiple commits into one, useful for cleaning up commit history.

10. **How do you view the commit history in Git? Are there ways to see it more concisely?**  
    Use `git log` to view history. Add `--oneline` for a concise view, or `--graph` for a visual of branches.

---

## Senior Developer

1. **Explain the concept of rebasing and how it affects commit history. What are the potential risks of `git rebase`?**  
   Rebasing changes the commit history, which can make it cleaner but may cause issues if done on a public branch due to rewritten history.

2. **How do you ensure code integrity and prevent unnecessary conflicts when working on long-running feature branches?**  
   Regularly merge the main branch into the feature branch to stay up-to-date and avoid large-scale conflicts.

3. **What is Gitflow? Explain how you might set up a Gitflow workflow in a large team.**  
   Gitflow is a workflow with branches for features, releases, and hotfixes, structured to streamline development. It uses a `develop` branch for ongoing work and `main` for releases.

4. **Describe the concept of a detached HEAD state. What can you do to fix it?**  
   A detached HEAD occurs when you check out a commit instead of a branch. To fix it, create a new branch from that state.

5. **How would you use Git hooks? Can you give examples of common hooks and use cases?**  
   Git hooks automate tasks. For example, a `pre-commit` hook can check code quality before commits, and `post-receive` can deploy code automatically.

6. **Explain the purpose of `git bisect`. How would you use it to debug an issue?**  
   `git bisect` uses binary search to find commits that introduced a bug, useful for narrowing down changes.

7. **What are some Git optimization techniques you’ve used or recommended in large projects?**  
   Techniques include rebasing branches frequently, using `.gitignore` effectively, and optimizing the `.git` directory to manage history.

8. **How do you manage large files or binary files in Git? What alternatives might you suggest?**  
   Use Git LFS (Large File Storage) or store them outside the repository, as Git isn’t designed for large binaries.

9. **Explain `git reflog` and its importance. When would you use it?**  
   `git reflog` records all actions in a repository, helpful for recovering lost commits.

10. **What are submodules in Git? How are they added and updated? What are some potential issues with submodules?**  
    Submodules allow you to include repositories inside others. Add them with `git submodule add <url>`. They can complicate workflows, as you need to update them separately.
