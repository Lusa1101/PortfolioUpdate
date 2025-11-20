import { Component, HostListener, NgModule, OnDestroy, OnInit } from '@angular/core';
import { RouterLink } from "@angular/router";
import { CommonModule, NgClass } from '@angular/common';

interface NavLink {
  name: string;
  href: string;
}

@Component({
  selector: 'app-header',
  templateUrl: './header.html',
  imports: [
    RouterLink,
    NgClass,
    CommonModule
  ],
})
export class Header implements OnInit, OnDestroy {
  isScrolled = false;
  open = false;

  navLinks: NavLink[] = [
    { name: 'Skills', href: '#skills' },
    { name: 'Projects', href: '#projects' },
    { name: 'Experience', href: '#experience' },
    { name: "Qualifications", href: "#qualifications" },
    { name: 'Blog', href: '/blog' },
    { name: 'Contact', href: '/contact' }
  ];

  ngOnInit(): void {
    window.addEventListener('scroll', this.handleScroll);
  }

  ngOnDestroy(): void {
    window.removeEventListener('scroll', this.handleScroll);
  }

  handleScroll = (): void => {
    this.isScrolled = window.scrollY > 10;
  };

  toggleMenu(): void {
    this.open = !this.open;

    // Testing
    console.log('Menu state:', this.open);
  }

  closeMenu(): void {
    this.open = false;
  }
}


/**
 * 
 * 
 * import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';

interface NavLink {
  name: string;
  href: string;
}

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit, OnDestroy {
  isScrolled = false;
  open = false;

  navLinks: NavLink[] = [
    { name: 'About', href: '/about' },
    { name: 'Projects', href: '/projects' },
    { name: 'Contact', href: '/contact' }
  ];

  ngOnInit(): void {
    window.addEventListener('scroll', this.handleScroll);
  }

  ngOnDestroy(): void {
    window.removeEventListener('scroll', this.handleScroll);
  }

  handleScroll = (): void => {
    this.isScrolled = window.scrollY > 10;
  };

  toggleMenu(): void {
    this.open = !this.open;
  }

  closeMenu(): void {
    this.open = false;
  }
}

 */