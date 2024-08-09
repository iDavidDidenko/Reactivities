import { Fragment, useEffect, useState } from 'react'
import axios from 'axios';
import { Container } from 'semantic-ui-react';
import { Activity } from '../Models/Activity';
import NavBar from './NavBar';
import ActivityDashboard from '../../Features/Activities/Dashboard/ActivityDashboard';
import {v4 as uuid} from 'uuid'

function App() {
	const [activities, setActivities] = useState<Activity[]>([]);
	const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);
	const [editMode, setEditMode] = useState(false)

	//const a = useMemo(() => activities.find(x => x.id === selectedActivity?.id), [selectedActivity]);
	
	useEffect(() => {
		// response data in of type Activity.
		axios.get<Activity[]>('http://localhost:5000/api/activities')
			.then(response => {
				setActivities(response.data)
			})
	}, []) // execute once, and once only.

	function handleSelectActivity(id: string) {
		setSelectedActivity(activities.find(x => x.id === id));
		
	}

	function handleCancelSelectActivity() {
		setSelectedActivity(undefined);
	}

	function handleFormOpen(id?: string) {
		id ? handleSelectActivity(id) : handleCancelSelectActivity();
		setEditMode(true);
		
	}

	function handleFormClose() {
		setEditMode(false);
	}

	function handleCreateOrEditActivity(activity : Activity){
		activity.id
			? setActivities([...activities.filter(x => x.id !== activity.id), activity])
			: setActivities([...activities, {...activity, id: uuid()}])
		setEditMode(false);
		setSelectedActivity(activity);
	}

	function handleDeleteActivity(id: string){
		setActivities([...activities.filter(x => x.id !== id)])
	}

	return (
		<Fragment>
			<NavBar openForm={handleFormOpen}/>
			<Container style={{ marginTop: '7em' }}>
				<ActivityDashboard
					activities={activities}
					selectedActivity={selectedActivity}
					selectActivity={handleSelectActivity}
					cancelSelectActivity={handleCancelSelectActivity}
					editMode={editMode}
					openForm={handleFormOpen}
					closeForm={handleFormClose}
					CreateOrEdit={handleCreateOrEditActivity}
					deleteActivity={handleDeleteActivity}
				/>
			</Container>
		</Fragment>
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
