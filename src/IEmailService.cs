using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using OneOf;
using OneOf.Types;

namespace Biplov.Email;

public interface IEmailService
{
    /// <summary>
    /// Sends an email message.
    /// </summary>
    /// <param name="subject">The subject of the email.</param>
    /// <param name="message">The body of the email.</param>
    /// <param name="receivers">The list of email addresses of the recipients.</param>
    /// <param name="sender">The email address of the sender.</param>
    /// <param name="bcc">The list of email addresses of the blind carbon copy recipients.</param>
    /// <param name="replyTo">The email address to reply to.</param>
    /// <param name="isBodyHtml">Indicates whether the body of the email is in HTML format.</param>
    /// <param name="correlationId">The correlation ID of the email.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A result indicating whether the email was sent successfully or an error occurred.</returns>
    Task<OneOf<Success, FormatException, AuthenticationException, SmtpException, TimeoutException, Exception>>
        SendAsync(
            string subject,
            string message,
            List<string> receivers,
            string sender,
            List<string>? bcc = null,
            string? replyTo = null,
            bool isBodyHtml = false,
            string? correlationId = null,
            CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an email message from the given template id.
    /// </summary>
    /// <param name="templateId">The id of the template to be used.</param>
    /// <param name="subject">The subject of the email.</param>
    /// <param name="message">The body of the email.</param>
    /// <param name="templateData">The template data to be replace from the message</param>
    /// <param name="receivers">The list of email addresses of the recipients.</param>
    /// <param name="sender">The email address of the sender.</param>
    /// <param name="bcc">The list of email addresses of the blind carbon copy recipients.</param>
    /// <param name="replyTo">The email address to reply to.</param>
    /// <param name="isBodyHtml">Indicates whether the body of the email is in HTML format.</param>
    /// <param name="correlationId">The correlation ID of the email.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A result indicating whether the email was sent successfully or an error occurred.</returns>
    /// <returns></returns>
    Task<OneOf<Success, FormatException, AuthenticationException, SmtpException, TimeoutException, Exception>>
        SendFromTemplateAsync(
            string templateId,
            string subject,
            string message,
            Dictionary<string, string> templateData,
            List<string> receivers,
            string sender,
            List<string>? bcc = null,
            string? replyTo = null,
            bool isBodyHtml = false,
            string? correlationId = null,
            CancellationToken cancellationToken = default);
}