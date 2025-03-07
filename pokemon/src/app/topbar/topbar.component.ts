import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.scss']
})
export class TopbarComponent implements OnInit {
  tabsWithIconAndText = [
    {
      id: 1,
      text: 'Pokemon',
      icon: 'group',
      route: '/pokemon'
    },
    {
      id: 2,
      text: 'Trainers',
      icon: 'user',
      route: '/trainers'
    },
    {
      id: 3,
      text: 'Regions',
      icon: 'globe',
      route: '/regions'
    },
    {
      id: 4,
      text: 'Moves',
      icon: 'ordersbox',
      route: '/moves'
    },
    {
      id: 5,
      text: 'Types',
      icon: 'palette',
      route: '/types'
    },
    {
      id: 6,
      text: 'Evolutions',
      icon: 'datatrending',
      route: '/evolutions',
    },
    {
      id: 7,
      text: 'Pictures',
      icon: 'image',
      route: '/pictures',
    },
  ];

  selectedIndex: number = 0;

  constructor(private router: Router) {}

  ngOnInit() {
    this.updateSelectedIndex(this.router.url);

    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.updateSelectedIndex(event.urlAfterRedirects);
      }
    });
  }

  updateSelectedIndex(url: string) {
    const index = this.tabsWithIconAndText.findIndex(tab => tab.route === url);
    this.selectedIndex = index !== -1 ? index : 0;
  }

  onTabClick(e: any) {
    const selectedTab = this.tabsWithIconAndText[e.itemIndex];
    if (selectedTab && selectedTab.route) {
      this.router.navigate([selectedTab.route]);
    }
  }
}
