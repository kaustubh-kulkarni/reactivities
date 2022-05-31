import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Header, List, ListItem } from 'semantic-ui-react';
import { Activity } from '../models/activity';

function App() {

  //Use state hook
  //[initial state, set the state]
  const [activities, setActivities] = useState<Activity[]>([]);

  //Use effect hook for possible functions
  useEffect(() => {
    axios.get<Activity[]>('http://localhost:5000/api/activities').then(response => {
      setActivities(response.data);
    });
  }, []); 


  return (
    <div>
      <Header as="h2" icon={'users'} content='Reactivities'/>
          <List>
          {activities.map(activity => (
            <List.Item key={activity.id}>
              {activity.title}
            </List.Item>
          ))}
          </List>
    </div>
  );
}

export default App;
