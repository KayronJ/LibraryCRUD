import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Book } from './book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private baseURL = "https://localhost:7197/Book";

  constructor(private httpClient: HttpClient) { }
  
  getBookList(): Observable<Book[]>{
    return this.httpClient.get<Book[]>(`${this.baseURL}`);
  }

  createBook(book: Book): Observable<Object>{
    return this.httpClient.post(`${this.baseURL}`, book);
  }

  getBookById(id: number): Observable<Book>{
    return this.httpClient.get<Book>(`${this.baseURL}/${id}`);
  }

  updateBook(id: number, book : Book): Observable<Object>{
    return this.httpClient.put(`${this.baseURL}/${id}`, book);
  }

  deleteBook(id: number): Observable<Object>{
    return this.httpClient.delete(`${this.baseURL}/${id}`);
  }
}
