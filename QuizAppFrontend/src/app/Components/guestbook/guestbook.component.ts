import { Component } from '@angular/core';
import { GuestbookService } from '../../Services/guestbook.service';
import { GuestbookEntry } from '../../Models/GuestbookEntry';
import { CommonModule, NgFor } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { ValidationService } from '../../Services/validation.service';

@Component({
  selector: 'app-guestbook',
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    FormsModule,
  ],
  templateUrl: './guestbook.component.html',
  styleUrl: './guestbook.component.scss',
})
export class GuestbookComponent {
  guestBookEntries: GuestbookEntry[] = [];

  newEntry: GuestbookEntry = {
    name: 'Lukas',
    message: 'Testmessage',
    createdAt: new Date().toISOString(),
  };

  nameError: string | null = null;
  messageError: string | null = null;

  constructor(
    private guestbookservice: GuestbookService,
    private validationservice: ValidationService
  ) {}

  ngOnInit(): void {
    this.loadEntries();
  }

  validateInputs(): boolean {
    this.nameError = this.validationservice.validateName(this.newEntry.name);
    this.messageError = this.validationservice.validateMessage(
      this.newEntry.message
    );

    return this.nameError === null && this.messageError === null;
  }

  postEntry(): void {
    if (!this.validateInputs()) {
      return;
    }
    this.guestbookservice.postEntry(this.newEntry).subscribe({
      next: () => {
        this.loadEntries();
        this.newEntry = {
          name: '',
          message: '',
          createdAt: new Date().toISOString(),
        };
        this.nameError = null;
        this.messageError = null;
      },

      error: (err) => {
        console.error('Fehler beim Speichern:', err);
      },
    });
  }

  loadEntries(): void {
    this.guestbookservice.getAllEntries().subscribe({
      next: (entries) => {
        console.log('Entries received:', entries);
        this.guestBookEntries = entries;
      },
      error: (err) => {
        console.error('Fehler beim Laden der Einträge:', err);
      },
    });
  }

  deleteEntries(): void {
    this.guestbookservice.deleteAllEntries().subscribe({
      next: (entries) => {
        console.log('Entries deleted' + entries);
        this.loadEntries();
      },
      error: (err) => {
        console.error('Fehler beim Löschen der Einträge', err);
      },
    });
  }
}
