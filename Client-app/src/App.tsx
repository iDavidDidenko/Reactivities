import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';


function App() {
  const [activities, setActivities] = useState([]);

  useEffect(()=> {
    axios.get('http://localhost:5000/api/activities')
    .then(response => {
      setActivities(response.data)
    })
  }, []) // execute once, and once only.


  return (
    <div>
      <Header as='h2' icon='users' content='Reactivities'/>
      <List>
        {activities.map((activity: any) =>(
          <List.Item key={activity.id}>
            {activity.title}
   
          </List.Item>
        ))}
      </List>
    </div>
    

   
  )
}
export default App

/*
if we want use JSX element, we will use:
{name}

- the Hook to remember things will be --> useState 
+ side effect --> when the page load, so before that it should get to API to feach data.
- the hook we use for sideEffect is --> useEffect
*/
