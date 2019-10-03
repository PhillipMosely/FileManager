import { Component, OnInit } from '@angular/core';
import { AuthService } from 'app/_services/auth.service';
import { Router } from '@angular/router';

@Component({
  moduleId: module.id,
  selector: 'app-filemanager',
  templateUrl: 'filemanager.component.html',
  styleUrls: ['filemanager.component.css']
})
export class FilemanagerComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    
    // if (!this.authService.LoggedIn()) {
    //   this.router.navigate(['/pages/login']);
    // }
  }

}
