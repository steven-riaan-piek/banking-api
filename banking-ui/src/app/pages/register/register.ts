import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class RegisterComponent {

  username = '';
  password = '';

  constructor(private api: ApiService) {}

  register() {
    this.api.register(this.username, this.password)
      .subscribe({
        next: () => alert('User registered'),
        error: () => alert('User already exists')
      });
  }
}