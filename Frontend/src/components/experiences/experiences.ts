import { Component, OnInit } from '@angular/core';
import { experienceData, sectionClass } from '../../app/data';
import { CommonModule } from '@angular/common';
import { Database } from '../../services/database';
import { Experience, JourneyData, Qualification } from '../../interfaces';

@Component({
  selector: 'app-experiences',
  imports: [CommonModule],
  templateUrl: './experiences.html',
  styleUrl: './experiences.css'
})
export class Experiences {
  experiences = experienceData;
  data: JourneyData[] = [];
  styles = sectionClass;

  constructor(private db: Database) {}

  ngOnInit() {
    this.loadExperiences();
  }

  async loadExperiences() {
    var data1: Experience[] = [];
    var data2: Qualification[] = [];

    await (await this.db.getExperience()).subscribe((data: any) => {
      data1 = data as Experience[];

      // Map Experience to JourneyData
      data1.forEach((exp) => {
        this.data.push({
          id: exp.id,
          type: 'Work',
          date: `${new Date(exp.startDate).getFullYear()} - ${new Date(exp.endDate).getFullYear()}`,
          name: exp.name,
          description: exp.description
        });
      });

    // Need to sort the data by date after combining experiences and qualifications
    this.data.sort((a, b) => {
      const dateA = parseInt(a.date.split(' - ')[0]);
      const dateB = parseInt(b.date.split(' - ')[0]);
      return dateB - dateA; // Sort in descending order
    })

      console.log('Fetched experiences from backend API: ', this.data);
    });

    (await this.db.getQualifications()).subscribe((data: any) => {
      data2 = data as Qualification[];

      // Map Qualification to JourneyData
      data2.forEach(qual => {
        this.data.push({
          id: qual.id,
          type: 'Education',
          date: `${new Date(qual.startDate).getFullYear()} - ${new Date(qual.endDate).getFullYear()}`,
          name: qual.name,
          description: qual.description
        });
      });

      console.log('Fetched qualifications from backend API: ', this.data);
    })
    
  }

  returnPosition(index: number) {
    return index % 2 === 0 ? "flex flex-col items-start gap-2 m-2" : "flex flex-col items-end gap-2 m-2";
  }

  returnStrokePosition(index: number) {
  return index % 2 === 0 ? "block w-0.5 max-h-full bg-[#677e7c] items-end justify-end" : "block w-0.5 max-h-full bg-[#677e7c] justify-start items-start";
  }

  returnTextPosition(index: number) {
    return index % 2 === 0 ? "items-end text-end" : "items-start text-start";
  }
}
