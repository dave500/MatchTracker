   M S B A M L   `   `   `  ����G  CMatchTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MatchTracker.ViewsMatchTracker.Views  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   (    "MatchTracker.Views.CompetitionView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MatchTracker.Views     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5	        � Title$  CompetitionView��5
   	   $	��450��6!   $	��800��6.   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   � $��1��6   $��7��6   $��0,0,0,20q�60   .+�5   
   �� ��5      �� 5        �� 	UriSource$ /Images/ASPitch-lg.png?�6   5"      �� 5#      $��Center=�6   ._�5$      �� $��5,2,5,2q�6   $��30(�6.   $��Medium"�6<   
���������6c   �� *Title+5%      5'      �� 5*   
   $��Center=�6   $��2��6-   $��3��6:   $��	10,0,10,0q�6J   ._�5+      �� $��15(�6   $��Medium"�6&   ��6:   �� *CompDDLabel+6Y   5,      �� 5-   
   -   5         ��Name$ Competitions��5-   0   $��2��6   $��4��6    $��10,20,20,20q�6F    �� DisplayMemberPath$
 Name��5/       �� SelectedItem 5.      ��  �� Path$ SelectedCompetition� �� Mode$ OneWayToSource=�5/      �� 52   
   $��	Get Games��6   $��3��6%   $��3��62   $��30��6B   $	��100��6N   .  (System.Windows.Interactivity.Interaction	   Triggers	 53      /  )System.Windows.Interactivity.EventTrigger  54      
   	EventName$
 Click��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 55      "  Caliburn.Micro.ActionMessage     
MethodName$ LoadMatchDetails��6(   56      58      5<      5=      