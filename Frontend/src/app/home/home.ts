import { Component } from '@angular/core';
import { Hero } from "../../components/hero/hero";
import { Skills } from "../../components/skills/skills";
import { Projects } from "../../components/projects/projects";
import { Qualifications } from "../../components/qualifications/qualifications";
import { Experiences } from "../../components/experiences/experiences";

@Component({
  selector: 'app-home',
  imports: [
    Hero,
    Skills,
    Projects,
    Qualifications,
    Experiences
],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {

}
  