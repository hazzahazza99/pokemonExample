import { Injectable } from '@angular/core';

export class Tab {
  id!: number;

  text?: string;

  icon?: string;

  route?: string;
}

const tabsWithIconAndText: Tab[] = [];

    @Injectable()
    export class Service {
        getTabsWithIconAndText(): Tab[] {
            return tabsWithIconAndText;
        }
    }