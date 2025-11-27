import { Component, OnInit } from '@angular/core';
import { sectionClass, skillsData } from '../../app/data';
import { CommonModule,  } from '@angular/common';
import { Database } from '../../services/database';
import { TechnologyStack } from '../../interfaces';

@Component({
  selector: 'app-skills',
  imports: [CommonModule],
  templateUrl: './skills.html',
  styleUrl: './skills.css'
})
export class Skills {
  data = skillsData;
  styles = sectionClass;
  skills: TechnologyStack[] = [];

  constructor(private db: Database) {

  }

  ngOnInit(): void {
    this.getProjects();
  }

  // Get the projects
  async getProjects() {
    try {
      var result = (await this.db.getProjects()).subscribe(data => {
        // console.log('Projects data received in skills section:', data.technologyStack);
        this.skills = data.technologyStack;
        
        this.skills = this.skills.sort((first, second) => first.name.localeCompare(second.name));
      });
      // console.log('Projects fetched successfully for skills section', result);
    }
    catch (error) {
      console.error('Error fetching projects in skills section:', error);
    }
  }
}
