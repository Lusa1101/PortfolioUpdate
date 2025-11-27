import { Component, OnInit } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Hero } from "../../components/hero/hero";
import { Skills } from "../../components/skills/skills";
import { Projects } from "../../components/projects/projects";
import { Qualifications } from "../../components/qualifications/qualifications";
import { Experiences } from "../../components/experiences/experiences";
import { Database } from '../../services/database';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    Hero,
    Skills,
    Projects,
    Qualifications,
    Experiences,
    HttpClientModule
],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {

  constructor(private db: Database) {

   }

   ngOnInit(): void {

   }

   async fetchData() {
    await this.db.getProjects().then(result => {
      console.log('Projects fetched in home component:', result);
    });
   }
}
  