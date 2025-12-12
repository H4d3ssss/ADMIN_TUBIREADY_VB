Public Class LoginForm
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'TODO: Implement secure password verification using Argon2id hashing.
        'Pseudocode / Plan (detailed):
        '1. Add required imports for Argon2 (Konscious.Security.Cryptography), SQL, encoding and crypto utilities.
        '2. Implement helper to generate cryptographically secure salt (random bytes).
        '3. Implement Argon2id hashing function:
        '   - Generate salt.
        '   - Configure Argon2id with chosen parameters: iterations, memory (KB), parallelism.
        '   - Compute hash bytes of fixed length.
        '   - Encode parameters, salt and hash into PHC-style string:
        '     "$argon2id$v=19$m={memory},t={iterations},p={parallelism}${base64salt}${base64hash}"
        '   - Return encoded string (store this in DB when creating user).
        '4. Implement parsing and verification function:
        '   - Parse PHC string into param block, salt and hash.
        '   - Base64-decode salt and expected hash.
        '   - Recompute hash with same params and salt.
        '   - Compare recomputed hash to stored hash using constant-time comparison.
        '   - Return boolean result.
        '5. In `btnLogin_Click`:
        '   - Read `txtUsername` and `txtPassword` (adjust names if different).
        '   - Query database for stored `PasswordHash` using parameterized SQL.
        '   - If found, call verify function; on success show `MainForm` and hide login form.
        '   - On failure show generic error.
        '6. Use safe defaults for Argon2 parameters (t=3, m=65536 KB = 64MB, p=1) and hash length (32 bytes).
        '7. Note: Add NuGet package `Konscious.Security.Cryptography` to the project and update `connectionString`.

        MainForm.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class