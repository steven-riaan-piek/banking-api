import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class LoginComponent {

  username = '';
  password = '';

  constructor(private api: ApiService) {}

  login() {
    this.api.login(this.username, this.password)
      .subscribe({
        next: () => alert('Login successful'),
        error: () => alert('Login failed')
      });
  }
}