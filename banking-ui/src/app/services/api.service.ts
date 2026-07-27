import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'http://localhost:5089/api/Bank';

  constructor(private http: HttpClient) {}

  register(username: string, password: string) {
    return this.http.post(`${this.baseUrl}/register`, {
      username,
      password
    });
  }

  login(username: string, password: string) {
    return this.http.post(`${this.baseUrl}/login`, {
      username,
      password
    });
  }

  getBalance(username: string) {
    return this.http.get(`${this.baseUrl}/${username}/balance`);
  }

  deposit(username: string, amount: number) {
    return this.http.post(`${this.baseUrl}/${username}/deposit`, amount);
  }

  withdraw(username: string, amount: number) {
    return this.http.post(`${this.baseUrl}/${username}/withdraw`, amount);
  }

  transfer(sender: string, receiver: string, amount: number) {
    return this.http.post(`${this.baseUrl}/${sender}/transfer/${receiver}`, amount);
  }

  getHistory(username: string) {
    return this.http.get(`${this.baseUrl}/${username}/history`);
  }
}