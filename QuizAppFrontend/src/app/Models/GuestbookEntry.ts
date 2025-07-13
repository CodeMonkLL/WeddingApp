export interface GuestbookEntry {
  id?: number;
  name: string;
  message: string;
  createdAt: string; // ISO-String (z. B. "2025-07-02T16:00:00Z")
}
