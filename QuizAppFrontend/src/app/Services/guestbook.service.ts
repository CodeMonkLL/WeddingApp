import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GuestbookEntry } from '../Models/GuestbookEntry';

@Injectable({
  providedIn: 'root',
})
export class GuestbookService {
  private apiUrl = 'http://localhost:8080/api/guestbook';
  // private apiUrl = 'http://192.168.178.31:8080/api/guestbook';

  constructor(private http: HttpClient) {}

  getAllEntries(): Observable<GuestbookEntry[]> {
    return this.http.get<GuestbookEntry[]>(this.apiUrl);
  }

  postEntry(entry: GuestbookEntry): Observable<GuestbookEntry> {
    return this.http.post<GuestbookEntry>(this.apiUrl, entry);
  }
  getEntryByName(name: String): Observable<GuestbookEntry> {
    return this.http.get<GuestbookEntry>(`${this.apiUrl}/${name}`);
  }

  deleteAllEntries(): Observable<GuestbookEntry> {
    return this.http.delete<GuestbookEntry>(this.apiUrl);
  }

  deleteEntryById(id: number): Observable<GuestbookEntry> {
    return this.http.delete<GuestbookEntry>(`${this.apiUrl}/${id}`);
  }
}
