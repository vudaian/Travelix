function isGmailEmail(email) {
    var emailRegex = /^[^\s@]+@gmail\.com$/i;

    var isGmail = emailRegex.test(email);

    return isGmail;
}