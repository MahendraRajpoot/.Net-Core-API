import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-contact',
  template: `
  <ul *ngIf="auth.user$ | async as user">
    <li>{{ user.name }}</li>
    <li>{{ user.email }}</li>
  </ul>`,
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  constructor(public auth: AuthService) { }

  ngOnInit(): void {
  }

}
 