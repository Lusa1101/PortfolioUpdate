import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-footer',
  imports: [CommonModule],
  templateUrl: './footer.html',
  styleUrl: './footer.css'
})
export class Footer {
   logos = [
    { 
      logo: "icons8-email-48.png",
      href: "mailto:omphu.shau@outlook.com",
      alt: "Email"
    },
    { 
      logo: "icons8-github-24.png",
      href: "https://github.com/lusa1101/",
      alt: "GitHub"
    },
    { 
      logo: "icons8-linkedin-50.png",
      href: "https://www.linkedin.com/in/omphulusa-mashau/",
      alt: "LinkedIn"
    }
  ];

  // Curre year
  currentYear = new Date().getFullYear();
}
