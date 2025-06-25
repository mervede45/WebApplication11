// assistant.js - Bu kodun tamamını kopyalayıp yapıştırın

let chatOpen = false;

function toggleChat() {
    const widget = document.getElementById('chatWidget');
    const badge = document.querySelector('.notification-badge');

    if (chatOpen) {
        widget.style.display = 'none';
        chatOpen = false;
    } else {
        widget.style.display = 'flex';
        chatOpen = true;
        if (badge) {
            badge.style.display = 'none';
        }
    }
}

function addMessage(content, isUser = false) {
    const messagesContainer = document.getElementById('chatMessages');
    const welcomeMsg = document.querySelector('.welcome-message');

    if (welcomeMsg && !isUser) {
        welcomeMsg.style.display = 'none';
    }

    const messageDiv = document.createElement('div');
    messageDiv.className = `message ${isUser ? 'user-message' : 'bot-message'}`;

    messageDiv.innerHTML = `
        <div class="message-avatar">${isUser ? 'U' : '🤖'}</div>
        <div class="message-content">${content}</div>
    `;

    messagesContainer.appendChild(messageDiv);
    messagesContainer.scrollTop = messagesContainer.scrollHeight;
}

function askQuestion(question) {
    addMessage(question, true);

    setTimeout(() => {
        let response = '';

        switch (question) {
            case 'Güçlü şifre nasıl oluştururum?':
                response = `🔒 <strong>Güçlü şifre için:</strong><br><br>
                        • En az 12 karakter kullanın<br>
                        • Büyük-küçük harf, sayı ve özel karakter karıştırın<br>
                        • Kişisel bilgilerinizi kullanmayın<br><br>
                        💡 <em>"Yeni Şifre Ekle" sayfasında otomatik şifre üreticisini kullanabilirsiniz!</em>`;
                break;

            case 'Zayıf şifrelerimi göster':
                response = `⚠️ <strong>2 zayıf şifre tespit edildi:</strong><br><br>
                        • Netflix - Son değişiklik: 180 gün önce<br>
                        • Gmail - Çok basit şifre<br><br>
                        🔧 Hemen "Güvenlik Analizi" sayfasından güncelleyebilirsiniz!`;
                break;

            case 'Kategori nasıl eklerim?':
                response = `📁 <strong>Kategori eklemek için:</strong><br><br>
                        1. Sol menüden "Kategoriler" seçin<br>
                        2. "Yeni Kategori" butonuna tıklayın<br>
                        3. Kategori adını girin ve renk seçin<br>
                        4. "Kaydet" butonuna basın<br><br>
                        💡 <em>Sosyal Medya, E-posta, Bankacılık gibi kategoriler öneriyorum!</em>`;
                break;

            case 'Güvenlik analizi nedir?':
                response = `🛡️ <strong>Güvenlik Analizi:</strong><br><br>
                        • Zayıf şifrelerinizi tespit eder<br>
                        • Tekrar eden şifreleri bulur<br>
                        • Eski şifreleri uyarır<br>
                        • Genel güvenlik skorunuzu hesaplar<br><br>
                        📊 Mevcut skorunuz: <strong>85/100</strong>`;
                break;

            default:
                response = `🤔 Bu konuda size yardımcı olmaya çalışıyorum. Lütfen yukarıdaki konulardan birini seçin.`;
        }

        addMessage(response);
    }, 1000);
}

// Sayfa yüklendiğinde çalışacak
$(document).ready(function () {
    setTimeout(() => {
        const badge = document.querySelector('.notification-badge');
        if (badge) {
            badge.style.display = 'flex';
        }
    }, 3000);
});