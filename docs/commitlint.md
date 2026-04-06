# Commitlint (Tool)

This document describes how to run `tools/commitlint.cs` locally and in CI.

## Commit lint

`commitlint.cs` validates commit headers using Conventional Commits.

Run with a direct message:

```bash
dotnet run --file tools/commitlint.cs -- --message "feat(player): add jump buffering"
```

Run with a commit message file (for `commit-msg` hooks):

```bash
dotnet run --file tools/commitlint.cs -- .git/COMMIT_EDITMSG
```

The local Git hook calls the script directly:

```bash
dotnet run --file tools/commitlint.cs -- "$1"
```

PR commit ranges are validated in CI by reading each commit subject from `git log` and passing it to `--message`.
