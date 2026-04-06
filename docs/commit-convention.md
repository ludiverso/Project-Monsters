# Commit Convention (Unity)

This project adopts the **Conventional Commits** standard to keep history clear, make reviews easier, and improve traceability for gameplay, content, and pipeline changes.

## Required format

Always use the first line in this format:

```text
type(scope): description
```

These are also accepted:

```text
type: description
type(scope)!: description
```

Rules:
- `type` must be lowercase.
- `scope` is optional and must be lowercase.
- `description` should be short, objective, and must not end with a period.

## Allowed types

The accepted types in this project are:

- `feat`: new functionality
- `fix`: bug fix
- `perf`: performance improvement
- `refactor`: refactoring without changing expected behavior
- `test`: tests
- `docs`: documentation
- `build`: build, dependencies, or compilation settings
- `ci`: CI pipeline and automation
- `chore`: general maintenance
- `style`: style or formatting changes with no logical impact
- `revert`: commit revert

## Recommended Unity scopes

Use `scope` to indicate the affected game area:

- `player`
- `enemy`
- `ai`
- `ui`
- `scene`
- `prefab`
- `animation`
- `audio`
- `input`
- `physics`
- `netcode`
- `save`
- `vfx`
- `render`
- `editor`
- `pipeline`
- `addressables`

## Valid examples

```text
feat(player): add jump buffering
fix(prefab): correct enemy spawn point
perf(scene): reduce overdraw in forest level
chore(addressables): reorganize group labels
ci(pipeline): validate commit messages in pull requests
docs(ui): document button navigation flow
```

## Invalid examples

```text
Update game
feat: ok.
Feat(player): add dash
fix(player)add dash
```

Common failure reasons:
- missing `type`
- missing `: ` after the header
- uppercase type
- description ending with a period

## Breaking changes

When there is a breaking change, use `!`:

```text
feat(save)!: migrate save format to v2
```

## Local validation

- Direct message:

```bash
dotnet run --file tools/commitlint.cs -- --message "feat(player): add dash"
```

- Message file (`commit-msg` hook):

```bash
dotnet run --file tools/commitlint.cs -- .git/COMMIT_EDITMSG
```

## Automated validation

- The `commit-msg` hook validates the message before the commit is completed.
- CI validates the PR title and the PR commits.
- For tool execution details, see [Commitlint (Tool)](commitlint.md).
