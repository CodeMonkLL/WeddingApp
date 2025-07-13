import { Injectable, isSignal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ValidationService {
  constructor() {}

  validateName(name: string): string | null {
    if (name.length < 2 || name.length > 50) {
      return 'Name muss zwischen 2 und 50 Zeichen lang sein.';
    }
    if (!/^[A-Za-z\s]+$/.test(name)) {
      return 'Name darf nur Buchstaben und Leerzeichen enthalten.';
    }
    return null;
  }

  validateMessage(message: string): string | null {
    if (message.length < 2 || message.length > 500) {
      return 'Nachricht muss zwischen 2 und 500 Zeichen lang sein.';
    }
    return null;
  }
}
