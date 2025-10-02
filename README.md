# MailService
Key Benefits:

✅ Fast testing – instantly verify email delivery without modifying your main project.

✅ Project-independent – test SMTP settings on any environment (local, dev, test, prod).

✅ Time-saving – quickly identify whether an issue is with the SMTP configuration, firewall/ports, or application code.

Use Cases:

Testing new SMTP configurations (Mail.ru, Gmail, Office365, internal SMTP, etc.).

Checking if firewall/port settings on a server block outgoing emails.

Running quick email delivery tests across multiple environments.

Troubleshooting email issues in your main application by isolating configuration from code.

How It Works:

Loads SMTP settings (SmtpServer, SmtpPort, SmtpUsername, SmtpPassword, FromEmail) from appsettings.json.

Prompts you to enter a recipient email address in the console.

Sends a test email via SMTP.

Displays success or error details in the console.
