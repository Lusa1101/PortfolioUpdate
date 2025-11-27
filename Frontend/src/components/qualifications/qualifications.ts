import { Component, OnInit } from '@angular/core';
import { qualificationsData, sectionClass } from '../../app/data';
import { CommonModule } from '@angular/common';
import { Database } from '../../services/database';
import { Certificate } from '../../interfaces';

@Component({
  selector: 'app-qualifications',
  imports: [CommonModule],
  templateUrl: './qualifications.html',
  styleUrl: './qualifications.css'
})
export class Qualifications {
  styles = sectionClass;
  qualifications: Certificate[] = [];//qualificationsData;

  constructor(private db: Database) {}

  ngOnInit() {
    this.loadQualifications();
  }

  async loadQualifications() {
    await (await this.db.getCertificates()).subscribe((data: any) => {
      this.qualifications = data;
      // Sort qualifications by issueDate in descending order
      this.qualifications.sort((a, b) => {
        return new Date(b.issueDate).getTime() - new Date(a.issueDate).getTime();
      });
      
      // console.log('Fetched certification from backend API: ', this.qualifications);
    });
  }
}
